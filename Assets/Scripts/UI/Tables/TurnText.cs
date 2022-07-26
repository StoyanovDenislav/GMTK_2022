using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnText : MonoBehaviour
{
    private Dice dice;
    private EnemyRoll EnemyRoll;
    public TextMeshProUGUI TextMesh;
    void Start()
    {
        dice = FindObjectOfType<Dice>();
        EnemyRoll = FindObjectOfType<EnemyRoll>();
    }

    // Update is called once per frame
    void Update()
    {


        if (dice.playerCanPlay)
        {
            TextMesh.text = "Player's turn";
        }
        
        if (EnemyRoll.canPlay)
        {
            TextMesh.text = "Rival's turn";
        } 
        if (dice.RoundFinished)
        {
            TextMesh.text = "End of Round";
        }

        if (dice.GameOver)
        {
            StartCoroutine(GameLost());
        }
        if (dice.Win)
        {
            StartCoroutine(GameWin());
        }
        
        


    }

    IEnumerator GameLost()
    {
        TextMesh.text = "You lost!"; 
        dice.GameOver = false;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameOver");
    }
    
    IEnumerator GameWin()
    {
        TextMesh.text = "You win!";
        dice.Win = false;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main");
    }
}
