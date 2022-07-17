using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Table2 : MonoBehaviour
{
    private bool collided = false;
    [SerializeField] private GameObject UiElement;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //UiElement.SetActive(true);
            collided = true;
        }

    }

    void Update()
    {
        if (collided == true)
        {
            UiElement.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && UiElement == true)
            {
                SceneManager.LoadScene("Table3");
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collided = false;
            UiElement.SetActive(false);
        }
    }
}
