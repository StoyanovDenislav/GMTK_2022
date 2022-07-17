using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardEventDisplay : MonoBehaviour
{
   public FifityFifty fiftyFifty;
    public HighRollDice HighRollDice;
    public TextMeshProUGUI TextMesh;
   
    public string text = " ";

 

    // Update is called once per frame
    void Update()
    {
        fiftyFifty = FindObjectOfType<FifityFifty>();
        
        
      HighRollDice = FindObjectOfType<HighRollDice>();
      
      


    }

    private void LateUpdate()
    {
        
       if (HighRollDice.highRoll)
        {
            text = "+1";
            StartCoroutine(textShow());
            HighRollDice.highRoll = false;

        }

        if (fiftyFifty.won)
        {
            text = "+3";
            StartCoroutine(textShow());
            fiftyFifty.won = false;

        }

        if (fiftyFifty.lost)
        {
            text = "-3";
            StartCoroutine(textShow());
            fiftyFifty.won = false;
        }


    }

   

    IEnumerator textShow()
     {
         TextMesh.text = text;

         yield return new WaitForSeconds(3);
         
         TextMesh.text = " ";
         

     }



}

