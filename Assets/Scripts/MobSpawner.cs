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

    private SpawnSide[] spawnSides = new SpawnSide[4];
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
        spawnSides[0] = new SpawnSide(
                    SpawnSide.TOP,
                    new Vector2(-this.boundaries.ScreenBounds.x, this.boundaries.ScreenBounds.y),
                     new Vector2(this.boundaries.ScreenBounds.x, this.boundaries.ScreenBounds.y),
                    -90f
                );

        spawnSides[1] = new SpawnSide(
                    SpawnSide.RIGHT,
                    new Vector2(this.boundaries.ScreenBounds.x, this.boundaries.ScreenBounds.y),
                    new Vector2(this.boundaries.ScreenBounds.x, -this.boundaries.ScreenBounds.y),
                    -180f
                );

        spawnSides[2] = new SpawnSide(
                    SpawnSide.BOTTOM,
                    new Vector2(this.boundaries.ScreenBounds.x, -this.boundaries.ScreenBounds.y),
                    new Vector2(-this.boundaries.ScreenBounds.x, -this.boundaries.ScreenBounds.y),
                    90f
                );


        spawnSides[3] = new SpawnSide(
                   SpawnSide.LEFT,
                    new Vector2(-this.boundaries.ScreenBounds.x, -this.boundaries.ScreenBounds.y),
                    new Vector2(-this.boundaries.ScreenBounds.x, this.boundaries.ScreenBounds.y),
                   0f
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
        SpawnSide screenSide = spawnSides[Random.Range(0, spawnSides.Length)];

        Quaternion rotation = Quaternion.Euler(
                0f, 
                0f, 
                screenSide.rotation + Random.Range(-RANDOM_ANGLE_RANGE, RANDOM_ANGLE_RANGE)
            );

        Vector2 position = new Vector2(
            Random.Range(screenSide.startPoint.x, screenSide.endPoint.x),
            Random.Range(screenSide.startPoint.y, screenSide.endPoint.y)
            );

        Instantiate(mobPrefab, position, rotation);
    }
}
