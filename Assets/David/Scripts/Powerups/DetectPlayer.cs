using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectPlayer : MonoBehaviour
{
    public GameObject buttonPrompt;
    public float radius = 5f;
    public GameObject itemSelectScreen;
    private bool playerInRange = false;

    public void Update()
    {
        SphereDetection();
       
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        if(context.performed && playerInRange)
        {
            itemSelectScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }

    }

    public void SphereDetection()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                playerInRange = true;
                break;
            }
        }
        buttonPrompt.SetActive(playerInRange);
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
