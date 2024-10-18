using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManagerComplete : MonoBehaviour
{
    public static AudioManagerComplete inst {get; private set;}
    
    private AudioSource audioSource;

    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip runSound;

    private void Awake() {
        if(inst != null && inst != this){
            Destroy(this.gameObject);
        } else {
            inst = this;
        }
        audioSource = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayJumpSound(){
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayRunSound(){
        audioSource.PlayOneShot(runSound);
    }
}
