using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public Sprite[] diceImages;
    public Button btn;
    private bool clicked = false;
    private float degr = 1;
    public float diceNum;
 

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
        diceNum = Random.Range(1, 6);
        btn.transform.GetComponent<Image>().sprite = diceImages[(int)diceNum - 1];
        clicked = true;

    }
}
