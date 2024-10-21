using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    private Vector3 originalPosition;
    [SerializeField] private Transform openedPosition;
    [SerializeField] private float doorMoveSpeed = 1.0f;
    private bool isDoorOpen = false;
    private bool isDoorMoving = false;
    
    private void Awake() {
        originalPosition = transform.position;
    }
    
    public void InteractWithDoor() {
        if (!isDoorMoving) {
            StartCoroutine(MoveDoor());
        }
    }

    private IEnumerator MoveDoor() {
        isDoorMoving = true;

        float time = 0;
        Vector3 startPosition, endPosition;

        // TODO: if the door is open, set the startPosition to where the door is currently, and the endPosition to where the door should end up
        //       if the door is closed, vice versa
        // hint: look at our declared variables above! 
        // if (isDoorOpen) {
        //     startPosition = ?
        //     endPosition = ?
        // } else {
        //     startPosition = ?
        //     endPosition = ?
        // }

        while (time < 1) {
            time += Time.deltaTime * doorMoveSpeed;
            // TODO: set the doors transform's CURRENT position to a Lerp between the start and end positions
            // https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
            // transform.position = Vector3.Lerp(???,???,???);

            yield return null;
        }

        isDoorOpen = !isDoorOpen;
        isDoorMoving = false; 
    }
}
