using UnityEngine;

public class deactivateBUtton : MonoBehaviour
{
    public GameObject window;

    public void CloseWindow()
    {
       window.SetActive(false); // Deactivate the button   
        Time.timeScale = 1f; // Resume the game
    }
}
