
using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class HighRollDice : MonoBehaviour
{
    
    private Dice Dice;
    
    

    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
      

    }

    

    public void HighRoll()
    {
        if (Dice.playerCanPlay && !Dice.clicked)
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
            else
            {
                Dice.Roll();
            }



            Debug.Log(Dice.diceNum);


            Destroy(gameObject);

        }




    }

}


