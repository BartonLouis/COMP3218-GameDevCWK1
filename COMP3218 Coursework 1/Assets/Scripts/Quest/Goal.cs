using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Goal
{
    public Quest Quest;
    public string Description;
    public bool Completed;
    public int RequiredAmount;
    public int CurrentAmount;

    public event Action goalCompleted;
    public event Action goalUncompleted;

    public virtual void Init() {
    }

    public virtual void OnDestroy() {
    }

    public void Evaluate() {
        if (CurrentAmount >= RequiredAmount) {
            Complete();
        }
        if (Completed && CurrentAmount < RequiredAmount) {
            UnComplete();
        }
    }

    public void Complete() {
        Completed = true;
        goalCompleted();
        Quest.CheckGoals();
    }

    public void UnComplete() {
        Completed = false;
        goalUncompleted();
        Quest.CheckGoals();
    }


}
