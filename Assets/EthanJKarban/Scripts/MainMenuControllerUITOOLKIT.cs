using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuControllerUITOOLKIT : MonoBehaviour
{

    //public VisualElement SettingsPannel;
    public SetitngsPOPUP settingsPopup;

    public GameObject settingsMenu;
    public VisualElement ui;
    public Button playButton;
    public Button optionsButton;
    public Button quitButton;

    public AudioClip buttonSound;
    public string sceneName = "Titles";

    public void Awake()
    {
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
    }

    private void OnPlayButtonClicked()
    {
        gameObject.SetActive(false);
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        Time.timeScale = 1f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(sceneName);
        // SettingsPannel.visible = true;

    }
    private void OnOptionsButtonClicked()
    {
        Debug.Log("Options button clicked");
        

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
        Application.Quit();
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

}


