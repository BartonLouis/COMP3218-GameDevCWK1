using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyGoal : Goal
{
    public KeyCode ExpectedKey;
    public string KeyName;
    public PressKeyGoal(string keyName, KeyCode keyCode, Quest quest) {
        Quest = quest;
        KeyName = keyName;
        ExpectedKey = keyCode;
        Completed = false;
        RequiredAmount = 1;
        CurrentAmount = 0;
        Description = "Press the " + keyName + " key.";
        Debug.Log("Created Goal " + Description);
    }

    public override void Init() {
        base.Init();
        GameEvents.current.UserPressedKey += KeyPressed;
    }

    public void KeyPressed(KeyCode keyCode) {
        if (keyCode == ExpectedKey) {
            CurrentAmount++;
            Evaluate();
        }
    }
}
