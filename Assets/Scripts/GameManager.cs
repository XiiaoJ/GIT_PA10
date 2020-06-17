using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;  
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    public int Score = 0;

    public GameObject hide1;
    public GameObject hide2;
    public GameObject score;

    void Start()
    {
        thisManager = this;
        Time.timeScale = 0;
        hide1.SetActive(false);
        hide2.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
            StartGame();
    }

        public void UpdateScore(int value)
    {
        Score += value;
        Txt_Score.text = "SCORE : " + Score;
    }

    private void StartGame()
    {
        Score = 0;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";
        hide1.SetActive(true);
        hide2.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Txt_Message.text = "GAMEOVER! \nPRESS ENTER TO RESTART GAME.";
        Txt_Message.color = Color.red;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            print("Score: " + Score);
            Score += 10;
            Txt_Score.text = "Score: 0" + score;
            print("Score: " + Score);
        }
    }
}
