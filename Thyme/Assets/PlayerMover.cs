using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    //Code adapted from class example
    
    public Movement controller;
    public Animator Animator;
    bool jump = false;
    bool crouch = false;
	
    // Update is called once per frame
    void Update () {
        
        

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
