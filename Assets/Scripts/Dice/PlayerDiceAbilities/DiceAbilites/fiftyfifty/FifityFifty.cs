using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifityFifty : MonoBehaviour
{
    private Dice Dice;
    private string name = "FiftyFifty";
    private PlayerInventory playerInventory;
    public bool won = false;
    public bool lost = false;


    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
        playerInventory = FindObjectOfType<PlayerInventory>();

    }
    



    public void FiftyFifty()
    {
        if (Dice.playerCanPlay && !Dice.clicked)
        {
            var randomNumber = Random.Range(1, 100);

            if (randomNumber <= 50)
            {
                won = true;
                Dice.Roll();

                Dice.diceNum += 3;

                Dice.lastScore = Dice.diceNum;

                if (Dice.lastScore >= 6)
                {
                    Dice.lastScore = 6;
                }



                Debug.Log(Dice.lastScore);


                Destroy(gameObject);

            }
            else
            {
                lost = true;
                Dice.Roll();
                Dice.diceNum -= 3;
                Dice.lastScore = Dice.diceNum;
                if (Dice.lastScore <= 1)
                {
                    Dice.lastScore = 1;
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
}
