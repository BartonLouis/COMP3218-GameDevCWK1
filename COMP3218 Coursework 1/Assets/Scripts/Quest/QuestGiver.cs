using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public string QuestType;
    [SerializeField]
    private GameObject Quests;
    public Quest Quest;


    public void AssignQuest() {
        Debug.Log("Assigning Quest");
        Quest = (Quest)Quests.AddComponent(System.Type.GetType(QuestType));
        QuestBoxManager.current.SetQuest(Quest);
    }
}
