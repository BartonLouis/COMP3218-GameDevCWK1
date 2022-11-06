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

    public virtual void Init() {
    }

    public void Evaluate() {
        if (CurrentAmount >= RequiredAmount) {
            Complete();
        }
    }

    public void Complete() {
        Completed = true;
        goalCompleted();
        Debug.Log("Completed goal " + Description);
        Quest.CheckGoals();
    }


}
