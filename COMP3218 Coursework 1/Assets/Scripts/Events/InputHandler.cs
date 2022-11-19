using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour  
{
    private void Update() {
        foreach (KeyCode vKey in Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(vKey)) {
                GameEvents.current.KeyPressed(vKey);
            }
        }
    }
}
