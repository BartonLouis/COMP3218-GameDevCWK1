using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheelGoal : Goal
{
    public int WheelID;
    public int ExpectedAngle;
    public int Range;

    public RotateWheelGoal(int wheelID, string Description, Quest quest, int angle, int range) {
        Quest = quest;
        WheelID = wheelID;
        Completed = false;
        RequiredAmount = 1;
        CurrentAmount = 0;
        this.Description = Description;
        ExpectedAngle = angle;
        Range = range;
    }

    public override void Init() {
        base.Init();
        GameEvents.current.TurnWheelRotated += WheelRotated;
    }
    public override void OnDestroy() {
        base.OnDestroy();
        GameEvents.current.TurnWheelRotated -= WheelRotated;
    }

    public void WheelRotated(int wheelID, float angle) {
        if (wheelID == WheelID) {
            Debug.Log("Here");
            int intAngle = Mathf.FloorToInt(angle);
            int minAngle = ExpectedAngle - Range;
            int maxAngle = ExpectedAngle + Range - minAngle;
            intAngle -= minAngle;
            if (intAngle >= 0 && intAngle <= maxAngle && !Completed) {
                CurrentAmount++;
            } else if ((intAngle < 0 || intAngle > maxAngle) && Completed) {
                CurrentAmount--;
            }
            Evaluate();
        }
    }
}
