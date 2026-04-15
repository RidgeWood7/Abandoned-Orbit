using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuControllerUITOOLKIT : MonoBehaviour
{

    //public VisualElement SettingsPannel;

    public VisualElement ui;
    public Button playButton;
    public Button optionsButton;
    public Button quitButton;

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
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(sceneName);
        // SettingsPannel.visible = true;

    }
    private void OnOptionsButtonClicked()
    {
        Debug.Log("Options button clicked");
        //SettingsPannel.SetActivePseudoState(true);
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

}


