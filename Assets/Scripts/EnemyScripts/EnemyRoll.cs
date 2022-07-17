using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoll : MonoBehaviour
{
    private Dice dice;
    public bool canPlay = false;
    public float enemyCurrentRoll;
    public float HealthBarPoints = 0;
    void Start()
    {
        dice = FindObjectOfType<Dice>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay && !dice.clicked)
        {
            dice.playerCanPlay = false;
            StartCoroutine(EnemyRollDice());
            

        }

    }

    IEnumerator EnemyRollDice()
    {
        yield return new WaitForSeconds(2);
        
        dice.StartCoroutine(dice.RollNumerator());
        enemyCurrentRoll = dice.diceNum;
        canPlay = false;
        dice.playerCanPlay = false;
        yield return new WaitForSeconds(3);
        dice.RoundFinished = true;









    }


}
