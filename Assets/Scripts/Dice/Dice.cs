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

    public bool playerCanPlay = true;

   public EnemyRoll enemyRoll;

   void Start()
   {
       enemyRoll = FindObjectOfType<EnemyRoll>();
   }



   private void Update()
    {
        if (!clicked)
        {
            var randomNumber = Random.Range(0, 5);
            btn.transform.GetComponent<Image>().sprite = diceImages[randomNumber];
           

        }

      
        
    }

    public void Roll()
    {


        if (playerCanPlay && !clicked)
        {
            StartCoroutine(RollNumerator());
            playerCanPlay = false;
            enemyRoll.canPlay = true;

        }

        
            




    }

    public IEnumerator RollNumerator()
    {
       

        diceNum = Random.Range(1, 6);
        btn.transform.GetComponent<Image>().sprite = diceImages[(int) diceNum - 1];
        clicked = true;
        
        yield return new WaitForSeconds(5);

        clicked = false;
      //  gameObject.SetActive(false);

    }


}
