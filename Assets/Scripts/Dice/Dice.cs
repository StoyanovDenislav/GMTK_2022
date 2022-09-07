using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public TextMeshProUGUI text;

    public Sprite[] diceImages;

    public Button btn;

    public bool clicked = false;

    public float diceNum;

    public float lastScore;

    public bool playerCanPlay = true;

    public EnemyRoll enemyRoll;

    public bool RoundFinished = false;

    public float HealthBarPoints = 0;

    public HealthBar HB;

    public EnemyHealthBar EHB;

    public bool GameOver = false;
    public bool Win = false;

    public AudioSource dice15;

    public bool CardUsed = false;

    private PlayerInventory _playerInventory;

    private string diff;

    public float timeRemaining = 10;

    public bool timerIsRunning = false;

    void Start()
    {
        enemyRoll = FindObjectOfType<EnemyRoll>();
        HB = FindObjectOfType<HealthBar>();
        EHB = FindObjectOfType<EnemyHealthBar>();
        _playerInventory = FindObjectOfType<PlayerInventory>();

        DifficultyData difficultyData = SaveSystem.LoadDifficulty();

       
        
        

        diff = difficultyData.diff;
    }


    private void Update()
    {
        if (!clicked && !RoundFinished && !GameOver)
        {
            var randomNumber = Random.Range(0, 6);
            btn.transform.GetComponent<Image>().sprite = diceImages[randomNumber];
            btn.transform.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
        else if (RoundFinished || GameOver)
        {
            btn.transform.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0 && !CardUsed)
            {
                timeRemaining -= Time.deltaTime;
                playerCanPlay = true;
                DisplayTime(timeRemaining);
            }
            else
            {
                StartCoroutine(TimerOff());
            }
        }

        if (!timerIsRunning && timeRemaining == 0)
        {
            timeRemaining = 10;
        }

        HB.UpdateHB();
        EHB.UpdateEHB();

        if (HealthBarPoints == 3)
        {
            GameOver = true;
            enemyRoll.canPlay = false;
            playerCanPlay = false;
        }
        else if (enemyRoll.HealthBarPoints == 3)
        {
            Win = true;
            enemyRoll.canPlay = false;
            playerCanPlay = false;
        }
    }

    public void Roll()
    {
        if (playerCanPlay && !clicked)
        {
            StartCoroutine(RollNumerator());
            lastScore = diceNum;
            enemyRoll.canPlay = true;
            dice15.Play();
        }
    }

    public IEnumerator RollNumerator()
    {
        
        clicked = true;

        diceNum = Random.Range(1, 7);

        btn.transform.GetComponent<Image>().sprite = diceImages[(int) diceNum - 1];

        yield return new WaitForSeconds(5);

        if (!CardUsed && diff.ToLower() == "Easy".ToLower() && !RoundFinished && _playerInventory.DiceScriptableObjects.Count != 0 )
        {
            timerIsRunning = true;
            clicked = true;
        }
        else
        {
            clicked = false;

            text.text = " ";
        }
        
      

       
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        text.text = "You have unused cards! You have " + seconds + " seconds to choose.";
    }

    IEnumerator TimerOff()
    {
        enemyRoll.canPlay = false;
        timeRemaining = 0;
        timerIsRunning = false;
        text.text = " ";
        yield return new WaitForSeconds(3);
        enemyRoll.canPlay = true;
        clicked = false;
    }


}