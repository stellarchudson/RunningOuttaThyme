using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour
{
    //Code adapted from class example
    
    public Movement controller;
    public Animator Animator;
    bool jump = false;
    bool crouch = false;
    [SerializeField] float runSpeed = 10f;
    private int jumpcount = 0;
    private int crouchcount = 0;
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update () {
        
        //transform.position += Vector3.right * Time.deltaTime * runSpeed;
        body.AddForce(transform.right * runSpeed);
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
            Animator.SetBool("Jump", true);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            crouch = true;
            Animator.SetBool("Crouch", true);
            
            
            
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            crouch = false;
        }

    }

    public void underLanding(bool isCrouch)
    {
        Animator.SetBool("Crouch", isCrouch);
    }

    public void onLanding()
    {
        Animator.SetBool("Jump", false);
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(crouch, jump);
        jump = false;
    }
 
  
    
    
  

    
}
