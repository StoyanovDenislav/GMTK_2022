using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScriptableObjectPickup : MonoBehaviour
{
    public DiceScriptableObject DiceScriptableObject;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = DiceScriptableObject.sprite;
    }
}
