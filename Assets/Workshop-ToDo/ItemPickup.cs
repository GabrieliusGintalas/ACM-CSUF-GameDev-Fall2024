using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private GameObject keyBindObj;
    private TextMeshProUGUI keyBindText;
    [SerializeField] private ItemSO item;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private string displayText = "Press E to pick up:";
    private bool isPlayerInRange = false;
    private AudioSource audioSource;
    private AudioClip interactSound;

    private void Awake() {
        //TODO: set the spriteRenderer sprite to the ItemSO's sprite
        keyBindText = keyBindObj.GetComponentInChildren<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start(){
        keyBindObj.SetActive(false);
        keyBindText.text = displayText + "\n" + item.itemName;
        interactSound = item.audioClip;
    }

    private void Update() {
        //TODO: if the player is in range and presses E [Input.GetKeyDown(KeyCode.E)] , call the PickUp method 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //TODO: if the player enters the trigger area, set the keybind object to active and set isPlayerInRange to true
        //    hint: remember to check if the other object is the player
    }

    private void OnTriggerExit2D(Collider2D other) {
        //TODO: if the player exits the trigger area, set the keybind object to inactive and set isPlayerInRange to false
        //    hint: remember to check if the other object is the player
    }

    public virtual void PickUp()
    {
        Debug.Log("You picked up: " + item.itemName);
        ModifyPlayerStats(item.itemType);

        if (interactSound != null)
        {
            audioSource.PlayOneShot(interactSound);
            float soundDuration = interactSound.length;

            StartCoroutine(DestroyAfterSound(soundDuration));
        }
        else
        {
            Destroy(gameObject);
        }

        spriteRenderer.enabled = false; 
        keyBindObj.SetActive(false);
    }

    private IEnumerator DestroyAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }


    public void ModifyPlayerStats(ItemType itemTyo){
        switch(itemTyo){
            case ItemType.SpeedBoost:
                PlayerStatsCompleted.inst.AddPlayerSpeed(item.speedBoostAmount);
                break;
            case ItemType.JumpBoost:
                PlayerStatsCompleted.inst.AddJumpForce(item.jumpBoostAmount);
                break;
        }
    }
}
