using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : NPC
{

    private bool canBeRead = false;

    // Update is called once per frame
    void Update()
    {
        if (canBeRead && Input.GetKeyDown(KeyCode.E)) {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            canBeRead = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            canBeRead = false;
        }
    }
}
