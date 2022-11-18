using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Condition
{
    [System.Serializable]
    public enum ConditionType
    {
        AlterCondition,
        KeyCondition,
        TurnWheelCondition,
        QuestCondition
    }
    public ConditionType conditionType;
    public bool complete = false;
    public int id = 0;
    public int expectedAngle = 0;
    public int range = 0;
    private bool canBeOpened = false;

    public virtual void Setup() {
        if (conditionType == ConditionType.AlterCondition) {
            GameEvents.current.AlterActivated += alterActivated;
            GameEvents.current.AlterDeactivated += alterDeactivated;
        } else if (conditionType == ConditionType.KeyCondition) {
            GameEvents.current.KeyPickedUp += pickedUpKey;
        } else if (conditionType == ConditionType.TurnWheelCondition) {
            GameEvents.current.TurnWheelRotated += wheelRotated;
        } else if (conditionType == ConditionType.QuestCondition) {
            GameEvents.current.UserCompletesQuest += QuestCompleted;
        }
    }

    private void Complete() {
        complete = true;
    }

    private void Uncomplete() {
        complete = false;
    }

    public void Interacted() {
        if (conditionType == ConditionType.KeyCondition && canBeOpened) {
            Complete();
        }
    }

    public void alterActivated(AlterController alter) {
        if (alter.ID == id) {
            Complete();
        }
    }

    public void alterDeactivated(AlterController alter) {
        if (alter.ID == id) {
            Uncomplete();
        }
    }

    public void pickedUpKey() {
        canBeOpened = true;
    }


    public void wheelRotated(int wheelID, float angle) {
        if (wheelID == id) {
            int intAngle = Mathf.FloorToInt(angle);
            int minAngle = expectedAngle - range;
            int maxAngle = expectedAngle + range - minAngle;
            intAngle -= minAngle;
            if (intAngle >= 0 && intAngle <= maxAngle && !complete) {
                Complete();
            } else if ((intAngle < 0 || intAngle > maxAngle) && complete) {
                Uncomplete();
            }
        }
    }

    public void QuestCompleted(int questID) {
        if (questID == id) {
            Complete();
        }
    }


}
