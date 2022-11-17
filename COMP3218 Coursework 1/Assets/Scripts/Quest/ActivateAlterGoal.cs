using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAlterGoal : Goal
{
    public int AlterID;

    public ActivateAlterGoal(int alterID, string Description, Quest quest) {
        Quest = quest;
        AlterID = alterID;
        Completed = false;
        RequiredAmount = 1;
        CurrentAmount = 0;
        this.Description = Description;
    }

    public override void Init() {
        base.Init();
        GameEvents.current.AlterActivated += this.AlterActivated;
        GameEvents.current.AlterDeactivated += this.AlterDeactivated;
    }


    public override void OnDestroy() {
        base.OnDestroy();
        GameEvents.current.AlterActivated -= this.AlterActivated;
        GameEvents.current.AlterDeactivated -= this.AlterDeactivated;
    }

    public void AlterActivated(AlterController alter) {
        if (alter.ID == AlterID) {
            CurrentAmount++;
            Evaluate();
        }
    }

    public void AlterDeactivated(AlterController alter) {
        if (alter.ID == AlterID) {
            CurrentAmount--;
            Evaluate();
        }
    }
}
