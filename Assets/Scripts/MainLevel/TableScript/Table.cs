using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Table : MonoBehaviour
{
    public LayerMask LayerMask;
    public GameObject table;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 3f, LayerMask);

        if (hit.name == "Table")
        {
            hit.GetComponent<bruh>().LevelChange();
        }


    }

    

}
