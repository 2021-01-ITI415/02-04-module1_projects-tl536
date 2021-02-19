using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 1f;
    // Distance where AppleTree turns around
    
    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position; // b
        pos.x += speed * Time.deltaTime; // c
        transform.position = pos; // d
                                  // Changing Direction
        if (pos.x < -6)
        { // a
            speed = Mathf.Abs(speed); // Move right // b
        }
        else if (pos.x > 11)
        { // c
            speed = -Mathf.Abs(speed); // Move left // c
        }

    }

}
