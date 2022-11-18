using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialStartScript : MonoBehaviour
{

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            text.enabled = false;
            Destroy(this);
        }
    }
}
