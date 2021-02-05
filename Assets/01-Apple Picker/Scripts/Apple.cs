﻿using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            // Get a reference to the ApplePicker component of Main Camera
            // Get a reference to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); // b
                // Call the public AppleDestroyed() method of apScript
            apScript.AppleDestroyed();
        }
    }
}