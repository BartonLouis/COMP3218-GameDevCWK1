using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest4 : Quest
{
    void Awake() {
        Debug.Log("Creating Quest");
        QuestId = 0;
        Name = "Let's get out of here";
        Description = "Opening chests";
        Goals.Add(new KeyPickUpGoal("Open the chest to get a key and exit the level!", this));
        foreach (Goal goal in Goals) {
            goal.Init();
        }
        CheckGoals();
    }
}
