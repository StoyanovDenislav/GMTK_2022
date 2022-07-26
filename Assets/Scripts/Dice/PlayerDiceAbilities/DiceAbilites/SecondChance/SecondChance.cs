using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondChance : MonoBehaviour
{
    private Dice Dice;
    private EnemyRoll enemyRoll;
    private PlayerInventory playerInventory;
    private CardAnimations cardanims;

    

    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
        enemyRoll = FindObjectOfType<EnemyRoll>();
        playerInventory= FindObjectOfType<PlayerInventory>();
        cardanims = GetComponent<CardAnimations>();

    }



    public void SecondChanceRoll()
    {
        if (Dice.playerCanPlay && !Dice.clicked)
        {

            Dice.Roll();

            Dice.playerCanPlay = true;

            enemyRoll.canPlay = false;

          /*  for (int i = 0; i < playerInventory.DiceScriptableObjects.Count; i++)
            {
                if (playerInventory.DiceScriptableObjects[i] == gameObject.name)
                {
                    playerInventory.DiceScriptableObjects.RemoveAt(i);
                    Destroy(gameObject);
                    SaveSystem.SavePlayer(playerInventory);

                    break;
                }*/

          cardanims.StartCoroutine(cardanims.Anims());


            }
        }
    }

