using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    private ItemGenerator itemGenerateScript;
    [SerializeField]
    private GameObject ItemGenerator;
    [SerializeField]
    private GameObject gameEndUI;
    private bool hasIncreacedSpeed30 = false;
    private bool hasIncreacedSpeed23 = false;
    private bool hasIncreacedSpeed12 = false;
    private bool hasIncreacedSpeed5 = false;
    GameObject timerText, pointText;
    float time = 30.0f;
    int point = 0;
    bool gameStarted;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started!");
        gameStarted = true;
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        ItemGenerator.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            this.time -= Time.deltaTime;
            this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
            this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";

            changeDropSpeed();
        }

        if (this.time <= 0 && gameStarted)
        {
            GameEnd();
        }
    }

    public void GameEnd()
    {
        Debug.Log("Game Ended!");
        ItemGenerator.SetActive(false);
        gameEndUI.SetActive(true);
        gameStarted = false;
    }

    public void GameRestart()
    {
        Debug.Log("Game Restart!");
        ItemGenerator.SetActive(true);
        gameEndUI.SetActive(false);
        gameStarted = true;
        this.time = 30.0f;
        this.point = 0;
    }

    public void changeDropSpeed()
    {
        if (time <= 30f && !hasIncreacedSpeed30)
        {
            Debug.Log("Set Game Speed : Level 1");
            hasIncreacedSpeed30 = true;
            itemGenerateScript.SetDropSpeed(0.01f);
            itemGenerateScript.SetBombRate(10);
            itemGenerateScript.SetGenerateInterval(1.0f);
        }

        if (time <= 23f && !hasIncreacedSpeed23)
        {
            Debug.Log("Set Game Speed : Level 2");
            hasIncreacedSpeed23 = true;
            itemGenerateScript.SetDropSpeed(0.02f);
            itemGenerateScript.SetBombRate(20);
            itemGenerateScript.SetGenerateInterval(0.8f);
        }

        if (time <= 12f && !hasIncreacedSpeed12)
        {
            Debug.Log("Set Game Speed : Level 3");
            hasIncreacedSpeed12 = true;
            itemGenerateScript.SetDropSpeed(0.03f);
            itemGenerateScript.SetBombRate(30);
            itemGenerateScript.SetGenerateInterval(0.5f);
        }

        if (time <= 5f && !hasIncreacedSpeed5)
        {
            Debug.Log("Set Game Speed : Level 4");
            hasIncreacedSpeed5 = true;
            itemGenerateScript.SetDropSpeed(0.04f);
            itemGenerateScript.SetBombRate(40);
            itemGenerateScript.SetGenerateInterval(0.7f);
        }
    }
}
