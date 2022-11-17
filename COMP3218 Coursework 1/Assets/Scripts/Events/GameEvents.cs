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
        Debug.Log("Alter Activated! " + alter.ID);
        if (AlterActivated != null) {
            AlterActivated(alter);
        }
    }

    public void DeActivateAlter(AlterController alter) {
        Debug.Log("Alter Deactivated! " + alter.ID);
        if (AlterDeactivated != null) {
            AlterDeactivated(alter);
        }
    }

    public void PickedUpKey() {
        Debug.Log("Key Picked up!");
        if (KeyPickedUp != null) {
            KeyPickedUp();
        }
    }

    public void RotatedWheel(int wheelID, float angle) {
        Debug.Log("Wheel rotated: " + angle);
        if (TurnWheelRotated != null) {
            TurnWheelRotated(wheelID, angle);
        }
    }

}
