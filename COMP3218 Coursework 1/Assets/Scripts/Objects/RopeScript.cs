using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    private Player player;
    public PushableObject pushable;
    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.current;
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, player.transform.localPosition);
        lineRenderer.SetPosition(1, pushable.transform.localPosition + pushable.baseOffset);
    }
}
