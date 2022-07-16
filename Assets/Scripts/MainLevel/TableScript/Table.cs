using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Table : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.name == "Table")
        {
            SceneManager.LoadScene("Table1");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
