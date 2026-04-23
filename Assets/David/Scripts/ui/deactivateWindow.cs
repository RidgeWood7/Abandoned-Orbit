using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.HighDefinition;

public class deactivateWindow : MonoBehaviour
{
    
    public GameObject window;
    private CharacterController player;



    private void Start()
    {
        player = FindFirstObjectByType<CharacterController>();
    }

    public void CloseWindow()
    {
        window.SetActive(false); 
        Time.timeScale = 1f; 
        Cursor.lockState = CursorLockMode.Locked;
        player.enabled = true;
        DetectPlayer.current.enabled = false;
        player.enabled = true;
        
        
    }
}
