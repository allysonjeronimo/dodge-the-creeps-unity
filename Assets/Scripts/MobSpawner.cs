using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    private static MobSpawner instance;

    public static MobSpawner Instance
    {
        get {
            if (instance == null)
            {
                Debug.Log("MobSpawner instance is null");
            }
            return instance; 
        }
    }

    [SerializeField]
    private GameObject mobPrefab;
    [SerializeField]
    private float spawnTimer = 0.5f;
    [SerializeField]
    private float startSpawnTimer = 0.5f;
    private Boundaries boundaries;
    private bool isSpawing;

    private struct SpawnSide
    {
        public Vector2 vector1;
        public Vector2 vector2;
        public float rotation;

        public SpawnSide(Vector2 vector1, Vector2 vector2, float rotation)
        {
            this.vector1 = vector1;
            this.vector2 = vector2;
            this.rotation = rotation;
        }
    }

    private const string TOP = "TOP";
    private const string RIGHT = "RIGHT";
    private const string BOTTOM = "BOTTOM";
    private const string LEFT = "LEFT";
    private Dictionary<string, SpawnSide> spawnSides = new Dictionary<string, SpawnSide>();
    private string[] spawnSideNames = { TOP, RIGHT, BOTTOM, LEFT };
    private const float RANDOM_ANGLE_RANGE = 45f;

    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        this.boundaries = GetComponent<Boundaries>();
        InitScreenSides();
    }

    private void InitScreenSides()
    {
        spawnSides.Add(
            TOP, new SpawnSide(
                    new Vector2(-this.boundaries.ScreenBounds.x, this.boundaries.ScreenBounds.y),
                     new Vector2(this.boundaries.ScreenBounds.x, this.boundaries.ScreenBounds.y),
                    -90f
                )
            );
        spawnSides.Add(
            RIGHT, new SpawnSide(
                    new Vector2(this.boundaries.ScreenBounds.x, this.boundaries.ScreenBounds.y),
                    new Vector2(this.boundaries.ScreenBounds.x, -this.boundaries.ScreenBounds.y),
                    -180f
                )
            );
        spawnSides.Add(
            BOTTOM, new SpawnSide(
                    new Vector2(this.boundaries.ScreenBounds.x, -this.boundaries.ScreenBounds.y),
                    new Vector2(-this.boundaries.ScreenBounds.x, -this.boundaries.ScreenBounds.y),
                    90f
                )
            );
        spawnSides.Add(
           LEFT, new SpawnSide(
                   new Vector2(-this.boundaries.ScreenBounds.x, -this.boundaries.ScreenBounds.y),
                    new Vector2(-this.boundaries.ScreenBounds.x, this.boundaries.ScreenBounds.y),
                   0f
               )
           );
    }

    public void StartSpawn()
    {
        isSpawing = true;
        StartCoroutine(SpawnMobs());
    }

    public void StopSpawn()
    { 
        isSpawing = false;
        StopCoroutine(SpawnMobs());
    }

    IEnumerator SpawnMobs()
    {
        yield return new WaitForSeconds(startSpawnTimer);

        while (isSpawing)
        {
            InstantiateMob();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void InstantiateMob()
    {
        string randomSideName = spawnSideNames[Random.Range(0, spawnSideNames.Length)];
        SpawnSide screenSide = spawnSides[randomSideName];

        Quaternion rotation = Quaternion.Euler(
                0f, 
                0f, 
                screenSide.rotation + Random.Range(-RANDOM_ANGLE_RANGE, RANDOM_ANGLE_RANGE)
            );

        Vector2 position = new Vector2(
            Random.Range(screenSide.vector1.x, screenSide.vector2.x),
            Random.Range(screenSide.vector1.y, screenSide.vector2.y)
            );

        Instantiate(mobPrefab, position, rotation);
    }
}
