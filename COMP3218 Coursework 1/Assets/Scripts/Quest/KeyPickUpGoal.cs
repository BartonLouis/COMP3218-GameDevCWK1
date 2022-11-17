using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpGoal : Goal
{

    public KeyPickUpGoal(string Description, Quest quest) {
        Quest = quest;
        Completed = false;
        RequiredAmount = 1;
        CurrentAmount = 0;
        this.Description = Description;
    }

    public override void Init() {
        base.Init();
        GameEvents.current.KeyPickedUp += KeyPickedUp;
        if (Player.current.carryingKey()) {
            CurrentAmount++;
            Evaluate();
        }
    }
    public override void OnDestroy() {
        base.OnDestroy();
        GameEvents.current.KeyPickedUp -= KeyPickedUp;
    }

    public void KeyPickedUp() {
        CurrentAmount++;
        Evaluate();
    }
}
