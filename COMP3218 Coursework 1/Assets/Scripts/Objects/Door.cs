using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int timeToDisplay = 3;
    [SerializeField]
    public Condition[] conditions;
    public int ID = 0;
    public bool allRequirements = true;

    public BoxCollider2D collider2;
    private Animator animator;
    private bool open = false;
    private bool canBeInteracted = false;

    [SerializeField] private AudioSource doorSoundEffect;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        foreach (Condition c in conditions) {
            c.Setup();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            canBeInteracted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            canBeInteracted = false;
        }
    }

    // Update is called once per frame
    void Update() {
        if (canBeInteracted && Input.GetKeyDown(KeyCode.E)) {
            foreach (Condition c in conditions) {
                c.Interacted();
            }
        }
        if (!open) {
            if (allRequirements) {
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
                foreach (Condition c in conditions) {
                    if (c.complete) {
                        Open();
                    }
                }
            }
        } else {
            if (allRequirements) {
                foreach (Condition c in conditions) {
                    if (!c.complete) {
                        Close();
                    }
                }
            } else {
                bool allIncomlete = true;
                foreach (Condition c in conditions) {
                    if (c.complete) {
                        allIncomlete = false;
                    }
                }
                if (allIncomlete) {
                    Close();
                }
            }
        }
    }

    public void Open() {
        Debug.Log("Opening");
        open = true;
        animator.SetBool("Open", true);
        doorSoundEffect.Play();
        GameEvents.current.OpenDoor(ID);
        collider2.enabled = false;
    }

    public void Close() {
        Debug.Log("Closing door");
        open = false;
        animator.SetBool("Open", false);
        doorSoundEffect.Play();
        GameEvents.current.CloseDoor(ID);
        collider2.enabled = true;
    }
}
