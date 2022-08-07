using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifityFifty : MonoBehaviour
{
    private Dice Dice;
    
    public bool won, lost = false;
    private CardAnimations cardanims;
    public bool started;


    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
        cardanims = GetComponent<CardAnimations>();
    }


    public void FiftyFifty()
    {
        if (!started)
        {
            started = true;
            

            if (Dice.playerCanPlay)
            {
               
                    Dice.Roll();
                    Calculate();
                    Dice.CardUsed = true;
            


                cardanims.StartCoroutine(cardanims.Anims());
            }

            void Calculate()
            {
                var randomNumber = Random.Range(1, 101);

                if (randomNumber <= 50)
                {
                    won = true;

                    Dice.lastScore += 3;

                    if (Dice.lastScore >= 6)
                    {
                        Dice.lastScore = 6;
                    }

                    Debug.Log(Dice.lastScore);
                }
                else
                {
                    lost = true;

                    Dice.lastScore -= 3;

                    if (Dice.lastScore <= 1)
                    {
                        Dice.lastScore = 1;
                    }

                    Debug.Log(Dice.lastScore);
                }
            }
        }
    }
}