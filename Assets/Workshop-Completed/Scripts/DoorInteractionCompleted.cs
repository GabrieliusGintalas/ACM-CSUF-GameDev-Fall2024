using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionCompleted : MonoBehaviour
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

        if (isDoorOpen) {
            startPosition = openedPosition.position;
            endPosition = originalPosition;
        } else {
            startPosition = originalPosition;
            endPosition = openedPosition.position;
        }

        while (time < 1) {
            time += Time.deltaTime * doorMoveSpeed;
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
        }

        isDoorOpen = !isDoorOpen;
        isDoorMoving = false; 
    }
}
