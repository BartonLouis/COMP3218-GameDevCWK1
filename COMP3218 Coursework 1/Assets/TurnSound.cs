using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSound : MonoBehaviour
{
    [SerializeField] private AudioSource turnSoundEffect;
    [SerializeField] private AudioSource woodSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            woodSoundEffect.Play();
            turnSoundEffect.Play();
        }
    }
}
