using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public CameraMovement.CameraMode CameraMode;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            CameraMovement.current.SetRoom(this);
        }   
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            CameraMovement.current.UnSetRoom(this);
        }
        Debug.Log("Unsetting room");
    }
}
