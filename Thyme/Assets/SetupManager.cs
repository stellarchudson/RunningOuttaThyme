using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupManager : MonoBehaviour
{
    [SerializeField] healthBar energy;
    // Start is called before the first frame update
    void Start()
    {
        energy.MaxHealth(100);
        StartCoroutine(runEnergy());
    }

    IEnumerator runEnergy()
    {
        while (energy.energy.value != 0)
        {
            energy.SetEnergy(-1);
            yield return new WaitForSeconds(10);
        }
        
    }

 
}
