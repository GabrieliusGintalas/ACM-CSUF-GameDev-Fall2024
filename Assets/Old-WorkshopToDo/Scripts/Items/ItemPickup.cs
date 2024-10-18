using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private GameObject keyBindObj;
    private TextMeshProUGUI keyBindText;
    [SerializeField] private ItemSO item;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool isPlayerInRange = false;

    private void Awake() {
        spriteRenderer.sprite = item.itemSprite;
        keyBindText = keyBindObj.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start(){
        keyBindObj.SetActive(false);
        keyBindText.text = "Press E to pick up " + item.itemName;
    }

    private void Update() {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E)){
            PickUp();
        }
    }

    //TODO: Implement logic for checking if player is within range of item + what logic should we change?
    /*
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(...)){
            ...
        }
    }
    */


    //TODO: Implement logic for checking if player is within range of item + what logic should we change?
    /*
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag(...)){
            ...
        }
    }
    */

    //CHALLENGE: Can you make text print "You have picked up: " + item.itemName before the item gets destroyed instead of using Debug.Log?

    public void PickUp(){
        Debug.Log("You picked up: " + item.itemName);
        Destroy(gameObject);
    }
}
