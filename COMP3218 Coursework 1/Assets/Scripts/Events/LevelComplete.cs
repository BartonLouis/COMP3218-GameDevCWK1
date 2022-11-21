using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public TextMeshProUGUI LevelCompleteText;
    public int timeToDisplay = 3;
    public string nextLevel = "MainMenu";
    [SerializeField] private AudioSource levelSoundEffect;
    private void Start() {
        LevelCompleteText.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        // Here you would load the next level
        Debug.Log("Level complete!");
        LevelCompleteText.enabled = true;
        levelSoundEffect.Play();
        StartCoroutine(DisableText());
    }

    IEnumerator DisableText() {
        yield return new WaitForSecondsRealtime(timeToDisplay);
        LevelCompleteText.enabled = false;
        SceneManager.LoadScene(nextLevel);
    }
}
