using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Door,
    SpeedBoost,
    JumpBoost
}

[CreateAssetMenu(fileName = "New Item", menuName = "Pickup/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public ItemType itemType;
    public AudioClip audioClip;
    public float speedBoostAmount;
    public float jumpBoostAmount;
}
