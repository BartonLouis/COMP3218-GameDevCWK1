using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeUrn : MonoBehaviour
{
    private ScoreScript scoreVal;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            //scoreVal.decrementScore();
            Destroy(gameObject);
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<BoxCollider>());
        }
    }
}
