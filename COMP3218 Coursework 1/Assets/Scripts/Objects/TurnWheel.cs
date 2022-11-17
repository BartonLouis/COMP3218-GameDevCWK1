using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWheel : MonoBehaviour
{
    public int ID = 0;
    public float angle = 0;
    public float prevAngle = 0;

    // Update is called once per frame
    void Update()
    {
        angle = Vector2.SignedAngle(transform.up, new Vector2(0, -1)) + 180f;
        if (angle != prevAngle) {
            GameEvents.current.RotatedWheel(ID, angle);
        }
        prevAngle = angle;
    }
}
