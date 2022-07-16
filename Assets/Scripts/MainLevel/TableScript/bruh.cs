using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bruh : MonoBehaviour
{

    public string c;

    public void LevelChange()
    {
        SceneManager.LoadScene(c);
    }
}
