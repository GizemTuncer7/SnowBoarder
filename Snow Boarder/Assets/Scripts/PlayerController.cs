using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount=1f;
    [SerializeField] float boostSpeed=30f;
    [SerializeField] float baseSpeed=20f;
    SurfaceEffector2D surfaceEffector;
    private bool canMove=true;
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        surfaceEffector=FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            RotatePlayer();
            RespondToBoost();
        }
        
    }
    public void DisableControls()
    {
        canMove=false;
    }
   void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector.speed = boostSpeed;
        }
        else
        {
            surfaceEffector.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}