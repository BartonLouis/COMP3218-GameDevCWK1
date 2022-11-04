using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveQuest : Quest
{
    // Start is called before the first frame update
    void Start() {
        Debug.Log("Creating Quest");
        QuestId = 0;
        Name = "Moving Basics";
        Description = "Getting to know the basics";
        Goals.Add(new PressKeyGoal("W", KeyCode.W, this));
        Goals.Add(new PressKeyGoal("A", KeyCode.A, this));
        Goals.Add(new PressKeyGoal("S", KeyCode.S, this));
        Goals.Add(new PressKeyGoal("D", KeyCode.D, this));
        foreach (Goal goal in Goals) {
            goal.Init();
        }
    }
}
