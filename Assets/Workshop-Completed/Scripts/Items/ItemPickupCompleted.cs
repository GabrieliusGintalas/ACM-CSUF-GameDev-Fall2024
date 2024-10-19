using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ItemPickupCompleted : MonoBehaviour
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
        spriteRenderer.sprite = item.itemSprite;
        keyBindText = keyBindObj.GetComponentInChildren<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start(){
        keyBindObj.SetActive(false);
        keyBindText.text = displayText + "\n" + item.itemName;
        interactSound = item.audioClip;
    }

    private void Update() {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E)){
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            keyBindObj.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            keyBindObj.SetActive(false);
            isPlayerInRange = false;
        }
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
