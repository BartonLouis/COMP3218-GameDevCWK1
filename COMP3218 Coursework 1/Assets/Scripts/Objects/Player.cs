using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player current;

    public float defaultSpeed = 5f;
    public Vector3 footOffset = new Vector3(0, 0.5f, 0);
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private bool hasKey = false;
    private int numberPulling = 0;
    private float speed;

    public void giveKey() {
        hasKey = true;
        GameEvents.current.PickedUpKey();
    }

    public bool carryingKey() {
        return hasKey;
    }

    public void Start() {
        current = this;
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        speed = defaultSpeed;
        
    }

    public void SetSpeed(float speed) {
        numberPulling++;
        Debug.Log("Setting speed");
        this.speed = speed;
    }

    public void UnsetSpeed() {
        numberPulling--;
        Debug.Log(numberPulling);
        if (numberPulling == 0) {
            this.speed = defaultSpeed;
            Debug.Log("Unsetting speed!");
        }
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
