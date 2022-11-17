using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public string QuestType;
    [SerializeField]
    private GameObject Quests;
    public Quest Quest;
    private bool given = false;


    public void AssignQuest() {
        Debug.Log("Assigning Quest");
        if (!given) {
            Destroy(Quests.GetComponent<Quest>());
            Quest = (Quest)Quests.AddComponent(System.Type.GetType(QuestType));
            QuestBoxManager.current.SetQuest(Quest);
            given = true;
        }
    }
}
