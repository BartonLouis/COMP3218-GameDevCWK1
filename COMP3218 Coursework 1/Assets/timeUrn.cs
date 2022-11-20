using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeUrn : MonoBehaviour
{
    public ScoreScript scoreVal;
    private bool canBe = false;

    void Update()
    {
        if(canBe == true && Input.GetKeyDown(KeyCode.E)){
            scoreVal.decrementScore();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!canBe && collision.tag == "Player") {
            canBe = true;
        }
    }
}
