using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float defaultSpeed = 5f;
    public float speed;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    public Vector3 footOffset = new Vector3(0, 0.5f, 0);
    // Start is called before the first frame update

    public void Start() {
        speed = defaultSpeed;   
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public void UnsetSpeed() {
        this.speed = defaultSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    
}
