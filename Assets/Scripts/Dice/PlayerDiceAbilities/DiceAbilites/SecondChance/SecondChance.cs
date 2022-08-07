using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondChance : MonoBehaviour
{
    private Dice Dice;
    private EnemyRoll enemyRoll;
    private CardAnimations cardanims;
    private bool started;


    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
        enemyRoll = FindObjectOfType<EnemyRoll>();
        cardanims = GetComponent<CardAnimations>();
    }


    public void SecondChanceRoll()
    {
        if (Dice.playerCanPlay && !started)
        {
            started = true;

            Dice.Roll();

            Dice.playerCanPlay = true;

            enemyRoll.canPlay = false;

            cardanims.StartCoroutine(cardanims.Anims());
        }
    }
}