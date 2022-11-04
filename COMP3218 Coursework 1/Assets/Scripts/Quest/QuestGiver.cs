using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public GameObject Quests;
    public string QuestType;
    public Quest Quest;

    // Start is called before the first frame update
    void Start()
    {
        AssignQuest();
    }

    public void AssignQuest() {
        Quest = (Quest)Quests.AddComponent(System.Type.GetType(QuestType));
    }
}
