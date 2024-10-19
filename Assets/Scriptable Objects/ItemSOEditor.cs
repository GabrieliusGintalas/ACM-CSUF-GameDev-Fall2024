using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemSO))]
public class ItemSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ItemSO itemSO = (ItemSO)target;

        itemSO.itemName = EditorGUILayout.TextField("Item Name", itemSO.itemName);
        itemSO.itemSprite = (Sprite)EditorGUILayout.ObjectField("Item Sprite", itemSO.itemSprite, typeof(Sprite), false);
        itemSO.itemType = (ItemType)EditorGUILayout.EnumPopup("Item Type", itemSO.itemType);

        if (itemSO.itemType == ItemType.SpeedBoost)
        {
            itemSO.speedBoostAmount = EditorGUILayout.FloatField("Speed Boost Amount", itemSO.speedBoostAmount);
        }

        if(itemSO.itemType == ItemType.JumpBoost)
        {
            itemSO.jumpBoostAmount = EditorGUILayout.FloatField("Jump Boost Amount", itemSO.jumpBoostAmount);
        }

        EditorUtility.SetDirty(target);
    }
}

