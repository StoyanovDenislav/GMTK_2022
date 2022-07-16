using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondChance : MonoBehaviour
{
    private Dice Dice;
    private EnemyRoll enemyRoll;
    private PlayerInventory playerInventory;
    private string name = "SecondChance";
    

    public void Start()
    {
        Dice = FindObjectOfType<Dice>();
        
        enemyRoll = FindObjectOfType<EnemyRoll>();
        
        playerInventory = FindObjectOfType<PlayerInventory>();
      

    }



    public void SecondChanceRoll()
    {
        if (Dice.playerCanPlay && !Dice.clicked)
        {
           
                Dice.Roll();

                Dice.playerCanPlay = true;

                enemyRoll.canPlay = false;
            
                
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
