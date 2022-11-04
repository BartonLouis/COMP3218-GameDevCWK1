using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour  
{
    // Start is called before the first frame update
    void Start()
    {

        GameEvents.current.UserPressedKey += KeyPressed;
    }

    public void KeyPressed(KeyCode keyCode) {
        switch (keyCode) {
            case KeyCode.W:
                Debug.Log("W key pressed");
                break;
            case KeyCode.A:
                Debug.Log("A key pressed");
                break;
            case KeyCode.S:
                Debug.Log("S key pressed");
                break;
            case KeyCode.D:
                Debug.Log("D key pressed");
                break;
            case KeyCode.LeftControl:
                Debug.Log("Ctrl key pressed");
                break;
            case KeyCode.Space:
                Debug.Log("Space key pressed");
                break;
        }
    }

    private void OnDestroy() {
        GameEvents.current.UserPressedKey -= KeyPressed;
    }
    private void Update() {
        foreach (KeyCode vKey in Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(vKey)) {
                GameEvents.current.KeyPressed(vKey);
            }
        }
    }
}
