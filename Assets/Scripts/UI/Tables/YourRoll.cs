using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YourRoll : MonoBehaviour
{
    private Dice dice;
    public TextMeshProUGUI TextMesh;
    void Start()
    {
        dice = FindObjectOfType<Dice>();
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh.text = dice.lastScore.ToString();

    }
}
