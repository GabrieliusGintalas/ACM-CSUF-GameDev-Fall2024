using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class AudioManagerComplete : MonoBehaviour
{
    public static AudioManagerComplete inst {get; private set;}
    
    private AudioSource audioSource;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private GameObject audioSettingsPanel;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private TextMeshProUGUI musicVolumeText;
    [SerializeField] private TextMeshProUGUI sfxVolumeText;
    private bool isAudioPanelActive = false;

    private void Awake() {
        if(inst != null && inst != this){
            Destroy(this.gameObject);
        } else {
            inst = this;
        }
        audioSource = GetComponent<AudioSource>();
        audioSettingsPanel.SetActive(false);
    }
    
    void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();

        musicVolumeSlider.value = 0.75f;
        sfxVolumeSlider.value = 0.75f;

        SetMusicVolume(musicVolumeSlider.value);
        SetSFXVolume(sfxVolumeSlider.value);    

        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void ToggleAudioSettingsPanel(){
        isAudioPanelActive = !isAudioPanelActive;
        audioSettingsPanel.SetActive(isAudioPanelActive);
    }

    public void SetMusicVolume(float value)
    {
        float volume = (value > 0) ? Mathf.Log10(value) * 20 : -80f;  
        bool result = audioMixer.SetFloat("Music", volume);
        Debug.Log("Setting Music Volume to: " + volume + ", Success: " + result);

        int volumePercentage = Mathf.RoundToInt(value * 100);
        musicVolumeText.text = volumePercentage.ToString();
    }

    public void SetSFXVolume(float value)
    {
        float volume = (value > 0) ? Mathf.Log10(value) * 20 : -80f; 
        bool result = audioMixer.SetFloat("Sound Effects", volume);
        Debug.Log("Setting SFX Volume to: " + volume + ", Success: " + result);

        int volumePercentage = Mathf.RoundToInt(value * 100);
        sfxVolumeText.text = volumePercentage.ToString();
    }


}
