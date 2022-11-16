using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{

    public bool canBePulled = false;
    public bool beingPulled = false;
    public PlayerMovement Player;
    public Vector3 baseOffset = new Vector3(0, 0.5f, 0);
    public float moveSpeed = 3;
    public LineRenderer lineRenderer;
    public AlterController goal;


    public void OnTriggerEnter2D(Collider2D collision) {
        canBePulled = true;
    }

    public void OnTriggerExit2D(Collider2D collision) {
        canBePulled = false;
        stopPulling();
    }

    private void stopPulling() {
        beingPulled = false;
        Player.UnsetSpeed();
        lineRenderer.enabled = false;
    }

    public void Update() {
        if (canBePulled && Input.GetKey(KeyCode.Space) && !beingPulled) {
            beingPulled = true;
            Player.SetSpeed(moveSpeed);
            lineRenderer.enabled = true;
        } else if (beingPulled && (!Input.GetKey(KeyCode.Space) || !canBePulled)) {
            stopPulling();
        }
    }

    public void FixedUpdate() {
        if (beingPulled) {
            // move the block to still be attached to the player
            float distance = (Player.transform.position - Player.footOffset - this.transform.position - baseOffset).magnitude;
            if (distance > 1.4) {
                this.transform.position += (Player.transform.position - Player.footOffset - this.transform.position - baseOffset).normalized * moveSpeed * Time.deltaTime;
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
