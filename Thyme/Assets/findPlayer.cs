using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findPlayer : MonoBehaviour
{
    
        [SerializeField] public Transform player;
        [SerializeField] public Animator animator;
        public healthBar energy;
        void Update()
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                
                energy.SetEnergy(-10);
                Debug.Log("ow");
            }

        }
}

