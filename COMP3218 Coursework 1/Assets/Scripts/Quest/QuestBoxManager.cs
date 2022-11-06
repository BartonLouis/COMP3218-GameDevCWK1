using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class QuestBoxManager : MonoBehaviour
{

    public static QuestBoxManager current;

    public GameObject questName;
    public GameObject goalPanel;

    public GameObject goalPrefab;

    // Start is called before the first frame update
    void Start()
    {
        current = this;     
    }

    public void SetQuest(Quest quest) {
        Debug.Log("Updating UI for quest creation: " + quest.Name);
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in goalPanel.transform)
            children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
        questName.GetComponent<TextMeshProUGUI>().text = quest.Name;
        foreach (Goal goal in quest.Goals) {
            // Sets up each of the UI elements for the goals in the quest
            GameObject goalUI = Instantiate(goalPrefab, goalPanel.transform);
            goalUI.GetComponentInChildren<RawImage>().enabled = false;
            goalUI.GetComponentInChildren<TextMeshProUGUI>().text = goal.Description;
            // Subscribes to the goalCompleted event for that goal, so that when it gets completed, the tick image appears
            goal.goalCompleted += (() => goalUI.GetComponentInChildren<RawImage>().enabled = true);
        }
    }

    void CompleteQuest() {
    
    }

}
