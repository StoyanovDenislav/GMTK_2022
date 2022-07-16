using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceCardCreator : MonoBehaviour
{
    public DiceScriptableObject DiceScriptableObject;

    public TextMeshProUGUI description;

    public Image cardSprite;

   

  
    void Start()
    {
        description.text = DiceScriptableObject.description;
        cardSprite.sprite = DiceScriptableObject.sprite;
        
        

    }

   
}
