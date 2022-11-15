using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Animator animator;
    private bool open = false;
    private bool canBeOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canBeOpened && Input.GetKeyDown(KeyCode.E)) {
            Open();
        }
    }

    public void Open() {
        Debug.Log("Opening");
        open = true;
        animator.SetBool("Open", true);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!open) {
            canBeOpened = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        canBeOpened = false;
    }
}
