using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ball : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // b
                                                              // Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>(); // c
                                                // Set the starting number of points to 0
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            other.gameObject.SetActive(false);
            int score = int.Parse(scoreGT.text); // d
                                                 // Add points for catching the apple
            score += 1;
            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();

        }
    }
}
