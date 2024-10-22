using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeOnPickup : ItemPickupCompleted
{
    public string sceneToLoad;
    
    public override void PickUp()
    {
        SceneController.instance.ChangeScene(sceneToLoad);
        Destroy(gameObject);
    }
}
