using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public static AudioManager inst {get; private set;}
    
    private AudioSource audioSource;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private GameObject audioSettingsPanel;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private TextMeshProUGUI musicVolumeText;
    [SerializeField] private TextMeshProUGUI sfxVolumeText;
    [SerializeField] private KeyCode toggleAudioSettingsKey = KeyCode.Escape;
    [SerializeField] private TextMeshProUGUI keyBindText;
    private bool isAudioPanelActive = false;

    private void Awake() {
        if(inst != null && inst != this){
            Destroy(this.gameObject);
        } else {
            inst = this;
        }
        audioSource = GetComponent<AudioSource>();
        audioSettingsPanel.SetActive(false);
        DontDestroyOnLoad(gameObject);
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
        keyBindText.text = "Press " + toggleAudioSettingsKey.ToString() + " to toggle audio settings";
    }

    void Update(){
        if(Input.GetKeyDown(toggleAudioSettingsKey)){
            ToggleAudioSettingsPanel();
        }
    }


    public void ToggleAudioSettingsPanel(){

        //TODO: set the isAudioPanelActive to the opposite of its current value

        //TODO: set audioSettingsPanel's active state to isAudioPanelActive
        //    hint: use the SetActive method of the GameObject class
    }


    public void SetMusicVolume(float value)
    {
        
        float volume = (value > 0) ? Mathf.Log10(value) * 20 : -80f;  

        //TODO: Set the "Music" float of the audioMixer to the volume value 
        //      hint: use the audioMixer.SetFloat(string, float) method

        //TODO: take the 'value' parameter (0 to 1) and convert it to a percentage (0 to 100)
        //      hint: use Mathf.RoundToInt to round the value to the nearest integer

        //TODO: set the text of the musicVolumeText to the volumePercentage
        //     hint: use the ToString method to convert the integer to a string
    }

    public void SetSFXVolume(float value)
    {
        
        float volume = (value > 0) ? Mathf.Log10(value) * 20 : -80f; 

        //TODO: Set the "Sound Effects" float of the audioMixer to the volume value 
        //      hint: use the audioMixer.SetFloat(string, float) method


        //TODO: take the 'value' parameter (0 to 1) and convert it to a percentage (0 to 100)
        //      hint: use Mathf.RoundToInt to round the value to the nearest integer


        //TODO: set the text of the sfxVolumeText to the volumePercentage
        //     hint: use the ToString method to convert the integer to a string
        
    }
}
