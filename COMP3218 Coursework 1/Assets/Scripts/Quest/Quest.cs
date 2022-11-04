using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int QuestId;
    public List<Goal> Goals = new List<Goal>();
    public string Name;
    public string Description;

    public void CheckGoals() {
        bool complete = true;
        foreach (Goal goal in Goals) {
            if (!goal.Completed) {
                complete = false;
            }
        }
        if (complete) {
            Complete();
        }
    }

    public void Complete() {
        Debug.Log("Quest " + Name + " completed!");
        GameEvents.current.QuestCompleted(QuestId);
    }

}
