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

}
