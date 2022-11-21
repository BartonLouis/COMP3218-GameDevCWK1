using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public static bool paused = false;
    public Animator animator;

    [SerializeField] private AudioSource pauseSoundEffect;
    private void Start() {
        UnPause();
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused && Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        } else if (paused && Input.GetKeyDown(KeyCode.Escape)) {
            UnPause();
        }
    }

    public void Pause() {
        Debug.Log("Pausing!");
        pauseSoundEffect.Play();
        animator.SetBool("Paused", true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void UnPause() {
        Time.timeScale = 1f;
        paused = false;
        animator.SetBool("Paused", false);
    }

    public void MainMenu() {
        UnPause();
        SceneManager.LoadScene("MainMenu");
    }
}
