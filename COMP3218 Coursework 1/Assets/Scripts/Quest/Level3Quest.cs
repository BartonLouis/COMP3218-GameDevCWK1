using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Quest : Quest
{
    void Awake() {
        Debug.Log("Creating Quest");
        QuestId = 0;
        Name = "Level 3";
        Description = "Opening chests";
        Goals.Add(new KeyPickUpGoal("Find the key!", this));
        Goals.Add(new OpenDoorGoal(0, "Use the key to open the final door!", this));
        foreach (Goal goal in Goals) {
            goal.Init();
        }
        CheckGoals();
    }
}
