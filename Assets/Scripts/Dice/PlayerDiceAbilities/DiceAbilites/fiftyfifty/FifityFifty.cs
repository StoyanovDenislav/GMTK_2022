using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifityFifty : MonoBehaviour
{
    private Dice Dice;
    
    

    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
      

    }



    public void FiftyFifty()
    {
        if (Dice.playerCanPlay && !Dice.clicked)
        {
            var randomNumber = Random.Range(1, 100);

            if (randomNumber <= 50)
            {
                Dice.Roll();

                Dice.diceNum += 3;

                if (Dice.diceNum >= 6)
                {
                    Dice.diceNum = 6;
                }

                

                Debug.Log(Dice.diceNum);


                Destroy(gameObject);

            }
            else
            {
                Dice.Roll();
                Dice.diceNum -= 3;
                if (Dice.diceNum <= 1)
                {
                    Dice.diceNum = 1;
                }
                Debug.Log(Dice.diceNum);
                Destroy(gameObject);
            }




        }
    }
}
