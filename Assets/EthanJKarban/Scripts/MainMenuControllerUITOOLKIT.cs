using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuControllerUITOOLKIT : MonoBehaviour
{

    //public VisualElement SettingsPannel;
    public SetitngsPOPUP settingsPopup;

    public AudioManager audioManager;

    public GameObject settingsMenu;
    public VisualElement ui;
    public Button playButton;
    public Button optionsButton;
    public Button quitButton;
    public Button creditsButton;

    public AudioClip buttonSound;
    public string sceneName = "Titles";
    public string creditsSceneName = "Credits";

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        ui = GetComponent<UIDocument>().rootVisualElement;

    }

    private void OnEnable()
    {
        playButton = ui.Q<Button>("PlayButton");
        playButton.clicked += OnPlayButtonClicked;

        optionsButton = ui.Q<Button>("OptionsButton");
        optionsButton.clicked += OnOptionsButtonClicked;

        quitButton = ui.Q<Button>("QuitButton");
        quitButton.clicked += OnQuitButtonClicked;

        creditsButton = ui.Q<Button>("CreditsButton");
        creditsButton.clicked += OnCreditsButtonClicked;
    }

    private void OnPlayButtonClicked()
    {
        gameObject.SetActive(false);
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(sceneName);
        // SettingsPannel.visible = true;

    }
    private void OnOptionsButtonClicked()
    {
        Debug.Log("Options button clicked");
        audioManager.PlaySFX(audioManager.Button);

        if (settingsMenu == true)
        {
            settingsMenu.SetActive(false);
        }
        if (settingsMenu == false)
        {
            settingsMenu.SetActive(true);
        }
        else
        {
            settingsMenu.SetActive(true);
        }

    }

    private void OnQuitButtonClicked()
    {
        audioManager.PlaySFX(audioManager.Button);
        Application.Quit();
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
    private void OnCreditsButtonClicked()
    {
        audioManager.PlaySFX(audioManager.Button);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(creditsSceneName);
    }

}


