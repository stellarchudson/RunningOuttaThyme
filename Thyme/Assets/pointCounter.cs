using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointCounter : MonoBehaviour
{
    public Text t1;
    
    public void SetText(int points)
    {
        // t1 = GetComponent<Text>();
        t1.text = "Points: " + points;
    }
}
