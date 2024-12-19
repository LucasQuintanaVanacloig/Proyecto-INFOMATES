using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Contador : MonoBehaviour
{
   public  TextMeshProUGUI contadorExamenes;
    int counter = 0;
    bool resuelto; 
    // Start is called before the first frame update
    void Start()
    {
        resuelto = false;
        //contadorExamenes = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void IncreaseScore(int points)
    {
        counter += points;  // Add points to score
        UpdateScoreText();  // Update the score text on screen
    }

    // Method to update the score text in the UI
    void UpdateScoreText()
    {
        contadorExamenes.text = "Score: " + counter.ToString();  // Display the score
    }
}
