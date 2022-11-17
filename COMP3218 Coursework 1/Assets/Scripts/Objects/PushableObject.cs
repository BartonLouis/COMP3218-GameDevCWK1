using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{

    public Vector3 baseOffset = new Vector3(0, 0.5f, 0);
    public float moveSpeed = 3;
    public LineRenderer lineRenderer;

    private Player player;
    private AlterController goal;
    private bool canBePulled = false;
    private bool beingPulled = false;

    private void Start() {
        player = Player.current;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            canBePulled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            canBePulled = false;
            if (beingPulled) {
                stopPulling();
            }
        }
    }

    private void stopPulling() {
        beingPulled = false;
        player.UnsetSpeed();
        lineRenderer.enabled = false;
    }

    private void startPulling() {
        beingPulled = true;
        player.SetSpeed(moveSpeed);
        lineRenderer.enabled = true;
    }

    public void Update() {
        if (canBePulled && Input.GetKey(KeyCode.Space) && !beingPulled) {
            startPulling();
        } else if (beingPulled && Input.GetKeyUp(KeyCode.Space)) {
            stopPulling();
        }
    }

    public void FixedUpdate() {
        if (beingPulled) {
            // move the block to still be attached to the player
            float distance = (player.transform.position - player.footOffset - this.transform.position - baseOffset).magnitude;
            if (distance > 1.4) {
                this.transform.position += (player.transform.position - player.footOffset - this.transform.position - baseOffset).normalized * moveSpeed * Time.deltaTime;
            }
        }
        if (goal != null) {
            float distance = (goal.transform.position + goal.offset - this.transform.position - baseOffset).magnitude;
            if (distance < 0.01) {
                this.transform.position = goal.transform.position + goal.offset - baseOffset;
            } else {
                this.transform.position += (goal.transform.position + goal.offset - this.transform.position - baseOffset).normalized * distance * moveSpeed * Time.deltaTime;
            }
        }
    }

    public void setGoal(AlterController goal) {
        this.goal = goal;
    }

    public void removeGoal() {
        this.goal = null;
    }
}
