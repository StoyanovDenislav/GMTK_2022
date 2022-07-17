using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public Sprite[] diceImages;
    
    public Button btn;
    
    public bool clicked = false;

    public float diceNum;

    public float lastScore;

    public bool playerCanPlay = true;

   public EnemyRoll enemyRoll;

   public bool RoundFinished = false;

   public float HealthBarPoints = 0;

   public HealthBar HB;

   public EnemyHealthBar EHB;

   public bool GameOver = false;

   void Start()
   {
       enemyRoll = FindObjectOfType<EnemyRoll>();
       HB = FindObjectOfType<HealthBar>();
       EHB = FindObjectOfType<EnemyHealthBar>();
   }



   private void Update()
    {
        HB.UpdateHB();
        EHB.UpdateEHB();

        if (HealthBarPoints == 3)
        {
            GameOver = true;
            enemyRoll.canPlay = false;
            playerCanPlay = false;

        }                                                                    

        if (!clicked && !RoundFinished && !GameOver)
        {
            var randomNumber = Random.Range(0, 5);
            btn.transform.GetComponent<Image>().sprite = diceImages[randomNumber];
            btn.transform.GetComponent<Image>().color = new Color(255, 255, 255, 1);
           

        } else if (RoundFinished || GameOver)
        {
            btn.transform.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }



    }

    public void Roll()
    {


        if (playerCanPlay && !clicked)
        {
            StartCoroutine(RollNumerator());
            lastScore = diceNum;
            playerCanPlay = false;
            enemyRoll.canPlay = true;
            
        }


    }

    public IEnumerator RollNumerator()
    {
       
        clicked = true;
        diceNum = Random.Range(1, 6);
        btn.transform.GetComponent<Image>().sprite = diceImages[(int) diceNum - 1];
        
        
        yield return new WaitForSeconds(3);

        clicked = false;
      //  gameObject.SetActive(false);

    }
    


}
