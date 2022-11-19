using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public enum CameraMode
    {
        Free,
        Average,
        Fixed
    }

    public static CameraMovement current;

    public Room currentRoom;
    private Room previousRoom;
    public float moveSpeed = 2;
    public float zoomTime = 1f;
    private CameraMode currentMode;
    private Vector3 goalPos;
    private float goalSize;


    private void Start() {
        current = this;
        goalSize = Camera.main.orthographicSize;
    }

    public void SetRoom(Room room) {
        previousRoom = currentRoom;
        currentRoom = room;
        currentMode = room.CameraMode;
        if (currentRoom.CameraMode != CameraMode.Free) {
            goalSize = 2 + currentRoom.GetComponent<BoxCollider2D>().size.y / 2;
        }
    }

    public void UnSetRoom(Room room) {
        if (room == currentRoom) {
            if (previousRoom == null) {
                currentMode = CameraMode.Free;
            } else {
                currentRoom = previousRoom;
                previousRoom = null;
                currentMode = currentRoom.CameraMode;
                goalSize = 2 + currentRoom.GetComponent<BoxCollider2D>().size.y / 2;
                if (currentRoom.CameraMode != CameraMode.Free) {
                    goalSize = 2 + currentRoom.GetComponent<BoxCollider2D>().size.y / 2;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (currentMode == CameraMode.Fixed) {
            goalPos = new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y, transform.position.z);
        } else if (currentMode == CameraMode.Average) {
            Vector3 p1 = Player.current.transform.position;
            Vector3 p2 = currentRoom.transform.position;
            goalPos = new Vector3((p1.x + p2.x) / 2, p2.y, transform.position.z);
        } else if (currentMode == CameraMode.Free) {
            goalPos = new Vector3(Player.current.transform.position.x, Player.current.transform.position.y, transform.position.z);
        }
        float distance = Vector3.Distance(transform.position, goalPos);
        if (distance < 0.01) {
            transform.position = goalPos;
        } else {
            this.transform.position += (goalPos - this.transform.position).normalized * Time.deltaTime * distance * moveSpeed;
        }
        if (currentRoom.CameraMode != CameraMode.Free) {
            distance = goalSize - Camera.main.orthographicSize;
            if (Mathf.Abs(distance) < 0.01) {
                Camera.main.orthographicSize = goalSize;
            } else {
                Camera.main.orthographicSize += (distance / zoomTime) * Time.deltaTime;
            }
        }

    }
}
