using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chest : MonoBehaviour
{


    public Animator animator;
    public TextMeshProUGUI pickedUpKeyText;
    public int timeToDisplay = 3;

    private Player player;
    private bool open = false;
    private bool canBeOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.current;
        pickedUpKeyText.enabled = false;
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
        player.giveKey();
        pickedUpKeyText.enabled = true;
        GameEvents.current.PickedUpKey();
        StartCoroutine(DisableText());
    }

    IEnumerator DisableText() {
        yield return new WaitForSecondsRealtime(timeToDisplay);
        pickedUpKeyText.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (!open && collision.tag == "Player") {
            canBeOpened = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            canBeOpened = false;
        }
    }
}
