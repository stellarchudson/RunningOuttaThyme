using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupManager : MonoBehaviour
{
    [SerializeField] healthBar energy;
    // Start is called before the first frame update
    void Start()
    {
        energy.MaxHealth(100);
        StartCoroutine(runEnergy());
    }

    private void Update()
    {
        if (energy.energy.value <= 0)
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        }
        
    }

    IEnumerator runEnergy()
    {
        while (energy.energy.value != 0)
        {
            energy.SetEnergy(-2);
            yield return new WaitForSeconds(1);
            Debug.Log("loseEnergy");
        }
        
    }

 
}
