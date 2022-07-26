using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifityFifty : MonoBehaviour
{
    private Dice Dice;

    //private PlayerInventory playerInventory;
    public bool won = false;
    public bool lost = false;
    public RectTransform rect;
    private CardAnimations cardanims;
    private string diff;
    public bool started;


    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
        //playerInventory= FindObjectOfType<PlayerInventory>();
        rect = GetComponent<RectTransform>();
        cardanims = GetComponent<CardAnimations>();
       
    }


    public void FiftyFifty()
    {
        if (!started)
        {
             started = true;
                    DifficultyData difficultyData = SaveSystem.LoadDifficulty();
            
                    diff = difficultyData.diff;
                    
                    if (Dice.playerCanPlay)
                    {
                        if (Dice.clicked && diff.ToLower() == "Easy".ToLower())
                        {
                            Calculate();
                            Dice.CardUsed = true;
                        }
                        else if (!Dice.clicked)
                        {
                            Dice.Roll();
                            Calculate();
                            Dice.CardUsed = true;
                        }
            
            
                        cardanims.StartCoroutine(cardanims.Anims());
                    }
            
                    void Calculate()
                    {
                        var randomNumber = Random.Range(1, 100);
            
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