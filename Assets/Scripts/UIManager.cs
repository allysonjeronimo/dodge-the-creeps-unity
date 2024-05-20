using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    [SerializeField]
    private float messageTimer = 2f;
    [SerializeField]
    private Text textScore;
    [SerializeField]
    private Text textMessage;
    [SerializeField]
    private Button buttonStart;
 
    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("UIManager instance is null");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void ShowMessage(string message, bool disposable = false)
    {
        textMessage.text = message;
        textMessage.enabled = true;
        if (disposable)
        {
            Invoke("HideMessage", messageTimer);
        }
    }

    private void HideMessage()
    {
        textMessage.enabled = false;
    }

    public void UpdateScore(int score)
    {
        textScore.text = score.ToString();
    }

    public void ButtonStartPressed()
    {
        buttonStart.gameObject.SetActive(false);
        GameManager.Instance.NewGame();
    }

    public void ShowGameOver()
    {
        StartCoroutine(ShowGameOverRoutine());
    }

    IEnumerator ShowGameOverRoutine()
    {
        ShowMessage("Game Over", true);
        yield return new WaitForSeconds(messageTimer);
        ShowMessage("Dodge the Creeps!", false);
        yield return new WaitForSeconds(1f);
        buttonStart.gameObject.SetActive(true);
    }
}
