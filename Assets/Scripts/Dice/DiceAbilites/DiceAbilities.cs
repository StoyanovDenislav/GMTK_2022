
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceAbilities : MonoBehaviour
{
   

    private Dice Dice;

    public void Start()
    {
        Dice = FindObjectOfType<Dice>();

    }

    public void HighRoll()
    {
       
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


    }

}


