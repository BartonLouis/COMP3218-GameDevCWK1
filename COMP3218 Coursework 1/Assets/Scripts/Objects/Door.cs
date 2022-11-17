using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int timeToDisplay = 3;
    [SerializeField]
    public Condition[] conditions;
    public int ID = 0;


    private Animator animator;
    private bool open = false;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        foreach (Condition c in conditions) {
            c.Setup();
        }
    }

    // Update is called once per frame
    void Update() {
        if (!open) {
            bool complete = true;
            foreach (Condition c in conditions) {
                if (!c.complete) {
                    complete = false;
                }
            }
            if (complete) {
                Open();
            }
        } else {
            bool complete = true;
            foreach (Condition c in conditions) {
                if (!c.complete) {
                    complete = false;
                }
            }
            if (!complete) {
                Close();
            }
        }
    }

    public void Open() {
        Debug.Log("Opening");
        open = true;
        animator.SetBool("Open", true);
        GameEvents.current.OpenDoor(ID);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Close() {
        Debug.Log("Closing door");
        open = false;
        animator.SetBool("Open", false);
        GameEvents.current.CloseDoor(ID);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}