using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrift : EnemyBase
{
    [SerializeField] public Transform player;
    [SerializeField] public Animator animator;
    // Start is called before the first frame update
   public override void Movement()
    {
        if (Vector2.Distance(transform.position, player.position) < 3)
            {
               animator.SetBool("isAttack", true);

            }

            else
            {
                animator.SetBool("isAttack", false);
            }
    }

   private void Update()
   {
       Movement();
   }
}
