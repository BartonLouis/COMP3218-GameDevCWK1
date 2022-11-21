using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
     [SerializeField] public AudioSource clickSoundEffect;
    // Start is called before the first frame update
    public void playSound(){
    
        clickSoundEffect.Play();
    }
    
}
