using System.Threading;
using TMPro;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectPlayer : MonoBehaviour
{
    public static Collider current;

    public GameObject buttonPrompt;
    public GameObject itemSelectScreen;
    public GameObject player;
    
    

    public bool playerInRange;
   

    public void Update()
    {
        playerInRange = buttonPrompt.activeSelf;
        
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        if (playerInRange && context.performed)
        {
            itemSelectScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Time.timeScale = 0f; // Pause the game

        }

    }

    public void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            buttonPrompt.SetActive(true);
            playerInRange = true;

            current = other;
        }


    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonPrompt.SetActive(false);
            playerInRange = false;

            current = null;
        }

    }
}
