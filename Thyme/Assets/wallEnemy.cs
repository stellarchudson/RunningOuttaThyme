using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallEnemy : EnemyBase
{

    public float deploymentHeight;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private LayerMask jimCarry;
    private bool groundHit = false;
    public static Collider2D circleCast;
    private bool movingRightAlong = false;
    [SerializeField] private LayerMask sonOfMask;

    private GameObject me;
    // Start is called before the first frame update
    public override void Movement()
    {
        Vector2 rasycastDir;  

        if (movingRightAlong)
        {
            rasycastDir = Vector2.right;
        }

        else
        {
            rasycastDir = Vector2.left;
        }

       
            rigid.AddForce((movingRightAlong ? Vector2.right : Vector2.left) * Time.fixedDeltaTime * 200);

            RaycastHit2D leftright = Physics2D.Raycast(transform.position, rasycastDir, 2, jimCarry);
          
        if (leftright.collider != null)
        {
            movingRightAlong = !movingRightAlong;
         
           
        }
    }

    private void Update()
    {
        Movement();
        //RaycastHit2D result = Physics2D.Raycast(me.transform.position, Vector2.down, deploymentHeight, sonOfMask);
    }
}
