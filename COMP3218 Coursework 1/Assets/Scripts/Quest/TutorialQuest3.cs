using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest3 : Quest
{
    void Awake() {
        Debug.Log("Creating Quest");
        QuestId = 2;
        Name = "Time to Spin";
        Description = "Getting to know your surroundings";
        Goals.Add(new RotateWheelGoal(0, "Rotate the left wheel", this, 45, 5));
        Goals.Add(new RotateWheelGoal(1, "Rotate the right wheel", this, 315, 5));
        foreach (Goal goal in Goals) {
            goal.Init();
        }
    }
}
