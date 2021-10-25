using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int speed = 10;
    [SerializeField] private int damageDealt = 10;
    public healthBar energy;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip clip;
    [SerializeField] public float volume=0.5f;

    public abstract void Movement();
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            energy.SetEnergy(-damageDealt);
            audioSource.PlayOneShot(clip, volume);
        }

    }
    
}
