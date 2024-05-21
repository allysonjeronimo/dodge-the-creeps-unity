using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private float scoreTimer = 1f;
    [SerializeField]
    private float startTimer = 2f;

    private bool isCountingScore;
    private int score;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
                Debug.Log("GameManager instance is null");

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void NewGame()
    {
        this.score = 0;
        Instantiate(playerPrefab);
        Invoke("StartTimers", startTimer);
        UIManager.Instance.UpdateScore(this.score);
        UIManager.Instance.ShowMessage("Get Ready!", true);
        AudioManager.Instance.PlayMusic("Theme");
    }

    private void StartTimers()
    {
        MobSpawner.Instance.StartSpawn();
        isCountingScore = true;
        StartCoroutine(CountScore());
    }

    public void GameOver()
    {
        MobSpawner.Instance.StopSpawn();
        isCountingScore = false;
        StopCoroutine(CountScore());
        UIManager.Instance.ShowGameOver();
    }

    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(scoreTimer);

        while (isCountingScore){
            this.score += 1;
            UIManager.Instance.UpdateScore(this.score);
            yield return new WaitForSeconds(scoreTimer);
        }
    }

}
