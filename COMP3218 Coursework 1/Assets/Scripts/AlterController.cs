using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterController : MonoBehaviour
{
    public PushableObject pushable;
    public Vector3 offset = new Vector3(0, 1.12f, 0);
    public RuneController[] runes;

    private bool activated = false;
    public int ID = 0;

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PushableObject") {
            pushable = collision.GetComponent<PushableObject>();
            pushable.setGoal(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (pushable != null) {
            pushable.removeGoal();
            pushable = null;
        }
    }
}
