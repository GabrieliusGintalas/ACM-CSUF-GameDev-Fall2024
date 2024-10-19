using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioCompleted : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip runSound;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayJumpSound(){
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayRunSound(){
        audioSource.PlayOneShot(runSound);
    }
}
