using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest1 : Quest
{
    void Awake() {
        Debug.Log("Creating Quest");
        QuestId = 0;
        Name = "Moving Basics";
        Description = "Getting to know your surroundings";
        Goals.Add(new PressKeyGoal("W", KeyCode.W, this));
        Goals.Add(new PressKeyGoal("A", KeyCode.A, this));
        Goals.Add(new PressKeyGoal("S", KeyCode.S, this));
        Goals.Add(new PressKeyGoal("D", KeyCode.D, this));
        foreach (Goal goal in Goals) {
            goal.Init();
        }
    }
}
