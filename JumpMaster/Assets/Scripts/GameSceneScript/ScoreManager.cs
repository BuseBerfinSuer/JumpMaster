using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text score;
    public static float scoreNumber;

    void Update()
    {
        score.text = scoreNumber.ToString();
    }

   
    
}
