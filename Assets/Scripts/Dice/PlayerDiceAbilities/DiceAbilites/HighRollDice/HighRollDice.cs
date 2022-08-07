using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class HighRollDice : MonoBehaviour
{
    private Dice Dice;
    public bool highRoll = false;
    private CardAnimations cardanims;
    private bool started;


    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
        cardanims = GetComponent<CardAnimations>();
    }


    public void HighRoll()
    {
        if (Dice.playerCanPlay && !started)
        {
            started = true;
            Dice.Roll();
            Calculate();
            Dice.CardUsed = true;

            cardanims.StartCoroutine(cardanims.Anims());
        }
    }

    private void Calculate()
    {
        var randomNumber = Random.Range(1, 101);

        if (randomNumber <= 20)
        {
            highRoll = true;
            
            Dice.lastScore = Dice.diceNum;

            if (Dice.lastScore == 6)
            {
                Dice.lastScore = 6;
            }
            else Dice.lastScore += 1;
        }
        else
        {
            highRoll = false;
        }


        Debug.Log(Dice.lastScore);
    }
}