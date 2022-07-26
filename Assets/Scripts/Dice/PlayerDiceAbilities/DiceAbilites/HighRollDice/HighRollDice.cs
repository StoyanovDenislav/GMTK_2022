
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
    private PlayerInventory playerInventory;
    private CardAnimations cardanims;
    
    

    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
        playerInventory= FindObjectOfType<PlayerInventory>();
        cardanims = GetComponent<CardAnimations>();
        
        

    }

    

    public void HighRoll()
    {
        if (Dice.playerCanPlay && !Dice.clicked)
        {
            var randomNumber = Random.Range(1, 100);

            if (randomNumber <= 20)
            {
                highRoll = true;
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
                highRoll = false;
                Dice.Roll();
            }



            Debug.Log(Dice.lastScore);
            
            /*for (int i = 0; i < playerInventory.DiceScriptableObjects.Count; i++)
            {
                if (playerInventory.DiceScriptableObjects[i] == gameObject.name)
                {
                    playerInventory.DiceScriptableObjects.RemoveAt(i);
                    Destroy(gameObject);
                    SaveSystem.SavePlayer(playerInventory);
                    
                    break;
                }
            }*/
            
            cardanims.StartCoroutine(cardanims.Anims());

        }




    }

}


