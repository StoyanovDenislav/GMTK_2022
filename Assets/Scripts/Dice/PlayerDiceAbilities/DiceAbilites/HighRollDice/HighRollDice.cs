
using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class HighRollDice : MonoBehaviour
{
    
    private Dice Dice;
    private PlayerInventory playerInventory;
    private string name = "HighRollDiceCard";
    
    

    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
        playerInventory = FindObjectOfType<PlayerInventory>();
      

    }

    

    public void HighRoll()
    {
        if (Dice.playerCanPlay && !Dice.clicked)
        {
            var randomNumber = Random.Range(1, 100);

            if (randomNumber <= 20)
            {
                Dice.Roll();

                Dice.lastScore = Dice.diceNum;

                if (Dice.lastScore == 6)
                {
                    Dice.lastScore = 6;
                }
                else Dice.lastScore += 1;




            }
            else
            {
                Dice.Roll();
            }



            Debug.Log(Dice.lastScore);

            for (int i = 0; i < playerInventory.DiceScriptableObjects.Count; i++)
            {
                if (playerInventory.DiceScriptableObjects[i] == name)
                {
                    playerInventory.DiceScriptableObjects.RemoveAt(i);
                    Destroy(gameObject);
                    SaveSystem.SavePlayer(playerInventory);
                    break;
                }

                
            }

            

        }




    }

}


