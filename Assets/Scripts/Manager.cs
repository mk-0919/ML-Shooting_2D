using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject player;
    [HideInInspector] public GameObject title;
    [HideInInspector] public GameObject ScoreUI;
    [HideInInspector] public GameObject GameOverUI;
    public GameObject WaveManager;
    public Timer timer;
    Text ScoreUItext;
    Text GameOverUItext;
    Text GameOverUIscore;
    int score = 0;
    private void Awake()
    {
        title = GameObject.Find("Canvas");
        ScoreUI = GameObject.Find("Score");
        GameOverUI = GameObject.Find("GameOver");
        ScoreUItext = ScoreUI.GetComponentInChildren<Text>();
        GameOverUItext = GameObject.Find("GameOverText").GetComponent<Text>();
        GameOverUI.SetActive(false);
    }

    private void Update()
    {
        if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X))
        {
            GameStart();
        }
        if (IsPlaying() == true && timer.countTime <= 0)
        {
            TimeUp();
        }
    }
    void GameStart()
    {
        title.SetActive(false);
        GameOverUI.SetActive(false);
        score = 0;
        timer.countTime = timer.setTime;
        timer.isCount = true;
        GameObject gameObjet = Instantiate(player, player.transform.position, player.transform.rotation);
    }

    public void GameOver()
    {
        GameOverUItext.text = "Game Over";
        GameOverUI.SetActive(true);
        timer.isCount = false;
        destroyObject();
    }
    public bool IsPlaying()
    {
        return title.activeSelf == false && GameOverUI.activeSelf == false;
    }
    public void GetScore(int num)
    {
        score += num;
        ScoreUItext.text = "Score : " + score;
    }
    public void TimeUp()
    {
        GameOverUItext.text = "Time Up!";
        GameOverUI.SetActive(true);
        timer.isCount = false;
        destroyObject();
    }
    public void destroyObject()
    {
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.tag == "Enemy" || obj.tag == "PlayerBullet" || obj.tag == "Player")
            {
                Destroy(obj);
            }
        }
    }
}
