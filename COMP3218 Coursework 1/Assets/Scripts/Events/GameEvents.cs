using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake() {
        current = this;
    }

    public event Action<KeyCode> UserPressedKey;
    public event Action<int> UserCompletesQuest;
    public event Action<AlterController> AlterActivated;
    public event Action<AlterController> AlterDeactivated;
    public event Action KeyPickedUp;
    public event Action<int, float> TurnWheelRotated;
    public event Action<int> DoorOpened;
    public event Action<int> DoorClosed;

    public void KeyPressed(KeyCode keyCode) {
        if (UserPressedKey != null) {
            UserPressedKey(keyCode);
        }
    }

    public void QuestCompleted(int questID) {
        if (UserCompletesQuest != null) {
            UserCompletesQuest(questID);
        }
    }

    public void ActivateAlter(AlterController alter) {
        if (AlterActivated != null) {
            AlterActivated(alter);
        }
    }

    public void DeActivateAlter(AlterController alter) {
        if (AlterDeactivated != null) {
            AlterDeactivated(alter);
        }
    }

    public void PickedUpKey() {
        if (KeyPickedUp != null) {
            KeyPickedUp();
        }
    }

    public void RotatedWheel(int wheelID, float angle) {
        if (TurnWheelRotated != null) {
            TurnWheelRotated(wheelID, angle);
        }
    }

    public void OpenDoor(int doorID) {
        if (DoorOpened != null) {
            DoorOpened(doorID);
        }
    }

    public void CloseDoor(int doorID) {
        if (DoorClosed != null) {
            DoorClosed(doorID);
        }
    }

}
