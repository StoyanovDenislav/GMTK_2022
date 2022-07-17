using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    public Texture2D Texture2d;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
       
        UnityEngine.Cursor.SetCursor(Texture2d, Vector2.zero, CursorMode.ForceSoftware);
        
    }

    
}
