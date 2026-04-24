using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.HighDefinition;

public class deactivateWindow : MonoBehaviour
{
    
    public GameObject window;
    private CharacterController player;
    private GameObject buttonPrompt;



    private void Start()
    {
        player = FindFirstObjectByType<CharacterController>();
        buttonPrompt = FindFirstObjectByType<DetectPlayer>().buttonPrompt;
    }

    public void CloseWindow()
    {
        window.SetActive(false); 
       
        Cursor.lockState = CursorLockMode.Locked;

        DetectPlayer.current.enabled = false;
        DetectPlayer.current.GetComponent<DetectPlayer>().playerInRange = false;
        DetectPlayer.current.GetComponent<DetectPlayer>().buttonPrompt.SetActive(false);
        DetectPlayer.current = null;

        player.enabled = true; 
        Time.timeScale = 1f; 


    }
}
