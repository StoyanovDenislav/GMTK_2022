using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Table : MonoBehaviour
{
    [SerializeField] private GameObject UiElement;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UiElement.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UiElement.SetActive(false);
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.name == "Table")
        {
            SceneManager.LoadScene("Table1");
        }
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
