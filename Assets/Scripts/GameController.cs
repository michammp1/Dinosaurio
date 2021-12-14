using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    Idle,
    Playing,
    Ended
}

public class GameController : MonoBehaviour
{

    public GameObject panel;
    public GameObject scorePanel;
    public GameObject player;
    public GameObject obstacleSpawner;
    public Text scoreText;
    public Text recordText;

    private float timer;

    public GameState gameState = GameState.Idle;

    void Start()
    {
        GetComponent<Parallax>().enabled = false;
        recordText.text = "Best: " + GetMaxScore().ToString();
    }

    void Update()
    {
        if(gameState == GameState.Idle)
        {
            panel.SetActive(true);
            scorePanel.SetActive(false);
        }

        if(gameState == GameState.Idle && (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)))
        {
            gameState = GameState.Playing;
            panel.SetActive(true);
            scorePanel.SetActive(false);
            player.SendMessage("UpdateState", "Dinosaurio_Run");
            obstacleSpawner.SendMessage("StartSpawn");
        }
        else if(gameState == GameState.Playing)
        {
            GetComponent<Parallax>().enabled = true;
            panel.SetActive(false);
            scorePanel.SetActive(true);
            IncreasePoints();
        }
        else if(gameState == GameState.Ended)
        {
            if(Input.GetKey(KeyCode.Return))
            {
                RestartGame();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void IncreasePoints()
    {
        timer = timer + Time.deltaTime;
        int intTimer = (int)timer;
        intTimer = Mathf.RoundToInt(timer);
        scoreText.text = "Score: " + intTimer.ToString();
        if(intTimer >= GetMaxScore())
        {
            recordText.text = "Best: " + intTimer.ToString();
            SaveScore(intTimer);
        }
    }

    public void StopScore(bool isStopped = false)
    {
        if(isStopped)
        {
            CancelInvoke("IncreasePoints");
        }
    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("Max Points", 0);
    }

    public void SaveScore(int currentPoints)
    {
        PlayerPrefs.SetInt("Max Points", currentPoints);
    }
}
