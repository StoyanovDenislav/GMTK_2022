using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera camera;
    public Vector2 wayPoint;
    private float ConstZ = -10;
    public float Offset;
    public GameObject waypoint;
    public ParticleSystem PlayerEffect;
    public Animator animator;


    private void Start()
    {
        camera = FindObjectOfType<Camera>();
        
    }

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            wayPoint = camera.ScreenToWorldPoint(Input.mousePosition);
            CreatePlayerEffect();
        }
        
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, 10 * Time.deltaTime);
            
        if (!waypoint.activeSelf && transform.position.x != wayPoint.x || transform.position.y != wayPoint.y)
        {
            waypoint.SetActive(true);
            waypoint.transform.position = wayPoint;
        }
        else waypoint.SetActive(false);
        
        camera.transform.position = Vector3.Lerp(new Vector3(camera.transform.position.x, camera.transform.position.y, ConstZ), 
            new Vector3(transform.position.x + Offset, transform.position.y, ConstZ), 5 * Time.deltaTime);


       

        animator.SetFloat("Horizontal", wayPoint.x);
        animator.SetFloat("Vertical", wayPoint.y);
        animator.SetFloat("Speed", wayPoint.sqrMagnitude);
    }

    void CreatePlayerEffect()
    {
        PlayerEffect.Play();
    }

}
