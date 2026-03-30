using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectPlayer : MonoBehaviour
{
    public GameObject buttonPrompt;

  
   public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonPrompt.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonPrompt.SetActive(false);
        }
    }
}
