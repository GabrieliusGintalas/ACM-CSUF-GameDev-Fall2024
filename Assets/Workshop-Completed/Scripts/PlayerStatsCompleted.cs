using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsCompleted : MonoBehaviour
{
    public static PlayerStatsCompleted inst { get; private set; }

    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI jumpText;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float playerJumpForce;

    void Awake() {
        if (inst != this && inst != null) {
            Destroy(gameObject);
        } else {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        UpdateUI();
    }

    public void AddPlayerSpeed(float speedBoost) {
        playerMoveSpeed += speedBoost; 
        UpdateUI();
    }

    public void AddJumpForce(float jumpBoost) {
        playerJumpForce += jumpBoost; 
        UpdateUI();
    }

    private void UpdateUI() {
        speedText.text = "Max Speed: " + playerMoveSpeed;
        jumpText.text = "Jump Strength: " + playerJumpForce;
    }

    public float GetPlayerMoveSpeed() {
        return playerMoveSpeed;
    }

    public float GetPlayerJumpForce() {
        return playerJumpForce;
    }
}

