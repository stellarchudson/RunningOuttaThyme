using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class PlayerMover : MonoBehaviour
{
    //Code adapted from class example
    
    public Movement controller;
    public Animator Animator;
    public bool jump = false;
    bool crouch = false;
    bool run = true;
    [SerializeField] float runSpeed = 10f;
    private float jumpcount = 0f;
    private Rigidbody2D body;
    private int jumpNum = 0;


    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update () {

        //transform.position += Vector3.right * Time.deltaTime * runSpeed;
        if (run)
        {
            body.AddForce(transform.right * runSpeed);
        }

        else
        {
            body.velocity = new Vector2(0,0);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(ManageJumpInput());

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

    //Event inputs: hit, landed
    //Implied: when we get here, we have pressed down the up arrow
    IEnumerator ManageJumpInput()
    {
        jumpcount = 0;
        //Start a timer

        while (Input.GetKey(KeyCode.UpArrow))
        {
            //Do nothing, wait until this is not true
            //jumpcount++;
            jumpcount += Time.deltaTime;

            if (jumpcount >= 2)
            {
                run = false;
                Debug.Log("ass");
            }
            yield return null;
        }
        
        
        
        
        //case 1: jump 
            //do normal jump code (jump = true)
            if (controller.IsGrounded)
            {
                jump = true;
                jumpNum++;
                Animator.SetBool("Jump", true);
            }

            //case 2: double
        //check if currently jumping, jump again
        if (!controller.IsGrounded)
        {
            jumpNum++;

            if (jumpNum >= 3)
            {
               jumpNum = 0;
               jump = false;
            }
            else
            {
                jump = true;
                Animator.SetBool("Jump", true);
            }
            //TODO: fix infinite jump
        }
        //case 3: hold
            //set run to no, jump special, run once landed
            if (controller.IsGrounded && jumpcount >= 3)
            {
                controller.JumpForce = 900f;
                jump = true;
                Animator.SetBool("Jump", true);
                


            }

            run = true;






    }
    

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(crouch, jump);
        
            jump = false;
      
        
        if (jump){
            Animator.SetBool("Jump", true);
        }
        else
        {
            Animator.SetBool("Jump", false);
           
        }
       
    }
 
  
    
    
  

    
}
