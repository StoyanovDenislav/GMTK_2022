using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowRollDice : MonoBehaviour
{
    private Dice Dice;

    private EnemyRoll enemyRoll;
    // Start is called before the first frame update
    void Start()
    {
        Dice = FindObjectOfType<Dice>();
        enemyRoll = FindObjectOfType<EnemyRoll>();
    }
    
    
    public void LowRoll()
    {
        if (Dice.playerCanPlay && !Dice.clicked)
        {
            var randomNumber = Random.Range(1, 100);

            if (randomNumber <= 10)
            {
                Dice.Roll();

                enemyRoll.enemyCurrentRoll -= 1;
                

            }
            else
            {
                Dice.Roll();
            }



            Debug.Log(enemyRoll.enemyCurrentRoll + " Enemy current roll");


            Destroy(gameObject);

        }




    }
}
