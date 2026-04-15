using UnityEngine;

public class deactivateWindow : MonoBehaviour
{
    public GameObject window;
    public DetectPlayer detectPlayer;
    private void Start()
    {
       
    }

    public void CloseWindow()
    {
        window.SetActive(false); // Deactivate the button   
        Time.timeScale = 1f; // Resume the game
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        detectPlayer.enabled =false; // Deactivate the detectPlayer script after item selection
    }
}
