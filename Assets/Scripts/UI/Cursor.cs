using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Texture2D Texture2d;

    public static Cursor Cursorr;

    // Start is called before the first frame update
    void Start()
    {
        if (Cursorr)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);


            UnityEngine.Cursor.SetCursor(Texture2d, Vector2.zero, CursorMode.ForceSoftware);
            Cursorr = this;
        }
    }
}