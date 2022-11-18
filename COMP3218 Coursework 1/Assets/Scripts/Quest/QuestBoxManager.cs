using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class QuestBoxManager : MonoBehaviour
{

    public static QuestBoxManager current;

    public TextMeshProUGUI questName;
    public VerticalLayoutGroup goalPanel;

    public GameObject goalPrefab;
    public Animator animator;

    private Quest currentQuest;

    // Start is called before the first frame update
    void Start()
    {
        current = this;     
    }

    public void SetQuest(Quest quest) {
        StopAllCoroutines();
        GameEvents.current.UserCompletesQuest += CompleteQuest;
        currentQuest = quest;
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in goalPanel.transform)
            children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
        questName.text = quest.Name;

        foreach (Goal goal in quest.Goals) {
            // Sets up each of the UI elements for the goals in the quest
            GameObject goalUI = Instantiate(goalPrefab, goalPanel.transform);
            if (!goal.Completed) {
                goalUI.GetComponentInChildren<RawImage>().enabled = false;
            } else {
                goalUI.GetComponentInChildren<RawImage>().enabled = true;
            }
            goalUI.GetComponentInChildren<TextMeshProUGUI>().text = goal.Description;
            // Subscribes to the goalCompleted event for that goal, so that when it gets completed, the tick image appears
            goal.goalCompleted += (() => goalUI.GetComponentInChildren<RawImage>().enabled = true);
            goal.goalUncompleted += (() => goalUI.GetComponentInChildren<RawImage>().enabled = false);
        }
        animator.SetBool("IsOpen", true);
    }

    IEnumerator CloseQuestBox() {
        yield return new WaitForSeconds(1f);
        animator.SetBool("IsOpen", false);
    }

    void CompleteQuest(int questID) {
        if (questID == currentQuest.QuestId) {
            StartCoroutine(CloseQuestBox());
        }
    }

}
