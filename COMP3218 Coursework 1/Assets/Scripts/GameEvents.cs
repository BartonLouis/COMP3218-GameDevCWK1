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

}
