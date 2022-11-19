using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterController : MonoBehaviour
{
    public List<PushableObject> queue = new List<PushableObject>();
    public PushableObject pushable;
    public Vector3 offset = new Vector3(0, 1.12f, 0);
    public RuneController[] runes;

    private bool activated = false;
    public int ID = 0;

    // Update is called once per frame
    void Update() {
        if (pushable != null) {
            float distance = (this.transform.position + offset - pushable.transform.position - pushable.baseOffset).magnitude;
            if (distance < 0.3 && !activated) {
                activated = true;
                GameEvents.current.ActivateAlter(this);
                foreach (RuneController rune in runes) {
                    rune.Activate();
                }
            } else if (distance >= 0.3 && activated) {
                activated = false;
                GameEvents.current.DeActivateAlter(this);
                foreach (RuneController rune in runes) {
                    rune.Deactivate();
                }
            }
        } else if (queue.Count > 0) {
            pushable = queue[0];
            queue.RemoveAt(0);
            pushable.setGoal(this);
        } else if (activated) {
            activated = false;
            GameEvents.current.DeActivateAlter(this);
            foreach (RuneController rune in runes) {
                rune.Deactivate();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PushableObject" && pushable == null) {
            pushable = collision.GetComponent<PushableObject>();
            pushable.setGoal(this);
        } else if (collision.tag == "PushableObject") {
            queue.Add(collision.GetComponent<PushableObject>());
        }
    }


    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("PushableObject") && pushable == collision.GetComponent<PushableObject>()) {
            pushable.removeGoal();
            pushable = null;
        }
        if (queue.Contains(collision.GetComponent<PushableObject>())) {
            queue.Remove(collision.GetComponent<PushableObject>());
        }
    }
}
