using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    public Sprite img4;

    private Dice dice;
    void Start()
    {
        dice = FindObjectOfType<Dice>();
        //gameObject.GetComponent<Image>().sprite = Sprites[0];
      
        
    }

    // Update is called once per frame
    public void UpdateHB()
    {

        
        switch (dice.HealthBarPoints)
        {
            case 1:
                gameObject.GetComponent<Image>().sprite = img2;
                break;
            case 2:
                gameObject.GetComponent<Image>().sprite = img3;
                break;
            case 3:
                gameObject.GetComponent<Image>().sprite = img4;
                break;
            
            default:
                gameObject.GetComponent<Image>().sprite = img1;
                break;
            
        }

       

    }
}
