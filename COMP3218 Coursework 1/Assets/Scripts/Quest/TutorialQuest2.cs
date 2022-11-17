using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest2 : Quest
{
    void Awake() {
        Debug.Log("Creating Quest");
        QuestId = 1;
        Name = "Pushing Blocks";
        Description = "Getting to know your surroundings";
        Goals.Add(new ActivateAlterGoal(0, "Activate the left Alter", this));
        Goals.Add(new ActivateAlterGoal(1, "Activate the right Alter", this));
        foreach (Goal goal in Goals) {
            goal.Init();
        }
    }
}
