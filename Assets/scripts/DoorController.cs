using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;

    private bool playerNearby = false;
    private bool isOpen = false;

    void Update()
    {
        if (playerNearby && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!isOpen)
            {
                doorAnimator.SetTrigger("mainDoorOpen");
                isOpen = true;
            }
            else
            {
                doorAnimator.SetTrigger("mainDoorClose");
                isOpen = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }
}