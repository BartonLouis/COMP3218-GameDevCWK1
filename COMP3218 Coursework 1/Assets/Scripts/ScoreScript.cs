using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    public int score;

    private float timer = 0f;
    public float delayAmount;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        if(sceneName == "Level1"){
        score = 0;
        }
        else{
        score = StateScoreController.globalScore;
        }

        scoreText.text = "Time: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
 
    if (timer >= delayAmount)
    {
       timer = 0f;
       score++;
       scoreText.text = "Time: " + score;
       StateScoreController.globalScore = score;
    }
    }
}