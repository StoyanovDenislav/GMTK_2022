using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardEventDisplay : MonoBehaviour
{
    public FifityFifty fiftyFifty;
    public HighRollDice HighRollDice;
    public TextMeshProUGUI TextMesh;
    public TextMeshProUGUI CardsUsed;
    private Dice dice;
    private string diff;
   

    public string text = " ";

    private void Start()
    {
        dice = FindObjectOfType<Dice>();
        DifficultyData difficultyData = SaveSystem.LoadDifficulty();
        diff = difficultyData.diff;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dice.CardUsed && dice.clicked && diff.ToLower() == "Easy".ToLower() && !dice.RoundFinished && dice.playerCanPlay)
        {
            CardsUsed.text = "You have unused cards! You have 10 seconds to choose.";
        }
        else
        {
            CardsUsed.text = " ";
        }

        fiftyFifty = FindObjectOfType<FifityFifty>();

        HighRollDice = FindObjectOfType<HighRollDice>();
        
        if (HighRollDice.highRoll)
        {
            text = "+1";
            StartCoroutine(textShow());
            HighRollDice.highRoll = false;
        }

        if (fiftyFifty.won)
        {
            text = "+3";
            StartCoroutine(textShow());
            fiftyFifty.won = false;
        }

        if (fiftyFifty.lost)
        {
            Debug.Log("Event Started");
            text = "-3";
            StartCoroutine(textShow());
            fiftyFifty.lost = false;
        }

       
    }

    private void LateUpdate()
    {
       
        
    }


    IEnumerator textShow()
    {
        TextMesh.text = text;

        yield return new WaitForSeconds(3);

        TextMesh.text = " ";
    }

   
}