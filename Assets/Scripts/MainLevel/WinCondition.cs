using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private Dice Dice;
    private EnemyRoll EnemyRoll;

    void Start()
    {
        Dice = FindObjectOfType<Dice>();
        EnemyRoll = FindObjectOfType<EnemyRoll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Dice.RoundFinished)
        {
            if (Dice.lastScore > EnemyRoll.enemyCurrentRoll)
            {
                EnemyRoll.HealthBarPoints++;

                Dice.lastScore = 0;
                Dice.diceNum = 0;
                EnemyRoll.enemyCurrentRoll = 0;
                EnemyRoll.canPlay = false;
                Dice.CardUsed = false;


                StartCoroutine(SwitchToPlayer());
            }
            else if (Dice.lastScore < EnemyRoll.enemyCurrentRoll)
            {
                Dice.HealthBarPoints++;
                Dice.lastScore = 0;
                Dice.diceNum = 0;
                EnemyRoll.enemyCurrentRoll = 0;
                Dice.CardUsed = false;


                StartCoroutine(SwitchToPlayer());
            }
            else if (Dice.lastScore == EnemyRoll.enemyCurrentRoll)
            {
                Dice.lastScore = 0;
                Dice.diceNum = 0;
                EnemyRoll.enemyCurrentRoll = 0;
                Dice.CardUsed = false;


                StartCoroutine(SwitchToPlayer());
            }
        }
    }

    public IEnumerator SwitchToPlayer()

    {
        yield return new WaitForSeconds(5);

        Dice.RoundFinished = false;

        Dice.playerCanPlay = true;
    }
}