using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorGoal : Goal
{

    public int DoorID;

    public OpenDoorGoal(int DoorID, string Description, Quest quest) {
        Quest = quest;
        this.DoorID = DoorID;
        Completed = false;
        RequiredAmount = 1;
        CurrentAmount = 0;
        this.Description = Description;
    }

    public override void Init() {
        base.Init();
        GameEvents.current.DoorOpened += DoorOpened;
        GameEvents.current.DoorClosed += DoorClosed;
    }
    public override void OnDestroy() {
        base.OnDestroy();
        GameEvents.current.DoorOpened -= DoorOpened;
    }

    public void DoorOpened(int doorID) {
        if (doorID == DoorID) {
            CurrentAmount++;
            Evaluate();
        }
    }

    public void DoorClosed(int doorID) {
        if (doorID == DoorID) {
            CurrentAmount--;
            Evaluate();
        }
    }
}
