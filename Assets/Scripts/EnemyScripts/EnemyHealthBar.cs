using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    public Sprite img4;

    private EnemyRoll _enemyRoll;
    void Start()
    {
      _enemyRoll= FindObjectOfType<EnemyRoll>();
        //gameObject.GetComponent<Image>().sprite = Sprites[0];
      
        
    }

    // Update is called once per frame
    public void UpdateEHB()
    {

        
        switch (_enemyRoll.HealthBarPoints)
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
