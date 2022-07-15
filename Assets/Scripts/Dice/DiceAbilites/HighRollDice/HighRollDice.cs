
using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class HighRollDice : MonoBehaviour
{
    
    private Dice Dice;
    public DiceScriptableObject DiceScriptableObject;
    public bool HighRollEnabled;
    

    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
        
        
    }

    

    public void HighRoll()
    {
        HighRollEnabled = true;                                                                
        var randomNumber = Random.Range(1, 100);
        
        if (randomNumber <= 20)
        {
            Dice.Roll();

            if (Dice.diceNum == 6)
            {
                Dice.diceNum = 6;
            }
            else Dice.diceNum += 1;
            
        }
        else Dice.Roll();
        
        
        Debug.Log(Dice.diceNum);

        HighRollEnabled = false;

    }

}


