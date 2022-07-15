using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public Camera camera;
    public Vector2 wayPoint;


    private void Start()
    {
        
        camera = FindObjectOfType<Camera>();
        
    }

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            wayPoint = camera.ScreenToWorldPoint(Input.mousePosition);

        }
        
        transform.position = Vector2.Lerp(transform.position, wayPoint, 5 * Time.deltaTime);


    }
}
