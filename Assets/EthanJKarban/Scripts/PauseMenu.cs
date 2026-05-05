using System.Collections;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
   
    public AudioMixerGroup mixer;
    public AudioManager audioManager;

    public float transitionTime = 1f;
    public Animator transition;
    

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();


    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        audioManager.PlaySFX(audioManager.Button);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu(string sceneName)
    {
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(sceneName);
    }
    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.Button);
        Debug.Log("Quitting game, bruh did you seriously click this button?");
        Application.Quit();
    }
    public void FullScreen(bool is_fullscreen)
    {
        audioManager.PlaySFX(audioManager.Button);
        Screen.fullScreen = is_fullscreen;
    }
}


