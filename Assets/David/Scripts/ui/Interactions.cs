using UnityEngine;

public class Interactions : MonoBehaviour
{
    public GameObject button;

    public void CloseWindow()
    {
        button.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }
}
