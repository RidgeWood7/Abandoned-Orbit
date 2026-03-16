using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public AudioClip buttonSound;
    public AudioMixerGroup mixer;

    public float transitionTime = 1f;
    public Animator transition;
    

    public void Awake()
    {


       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu(string sceneName)
    {
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        Time.timeScale = 1f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(sceneName);
    }
    public void QuitGame()
    {
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        Debug.Log("Quitting game, bruh did you seriously click this button?");
        Application.Quit();
    }
    public void FullScreen(bool is_fullscene)
    {
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        Screen.fullScreen = is_fullscene;
    }
}


