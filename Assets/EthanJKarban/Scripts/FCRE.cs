using UnityEngine;
using UnityEngine.UIElements;

public class FCRE : MonoBehaviour
{
    //public VisualElement SettingsPannel;

    public AudioManager audioManager;

    public VisualElement ui;

    public Button ExitButton;
    public Button LeftButton;
    public Button RightButton;

    public string sceneName = "Credits";
    public string creditsSceneName = "Credits";
    public string leftSceneName = "CK";
    public string rightSceneName = "CD";

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        ui = GetComponent<UIDocument>().rootVisualElement;

    }

    private void OnEnable()
    {
        ExitButton = ui.Q<Button>("Exit");
        ExitButton.clicked += OnExitButtonClicked;
        LeftButton = ui.Q<Button>("LeftButton");
        LeftButton.clicked += OnLeftButtonClicked;
        RightButton = ui.Q<Button>("RightButton");
        RightButton.clicked += OnRightButtonClicked;


    }

    private void OnExitButtonClicked()
    {
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1.5f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(creditsSceneName);
        // SettingsPannel.visible = true;

    }
    private void OnLeftButtonClicked()
    {
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1.5f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(leftSceneName);
    }
    private void OnRightButtonClicked()
    {
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1.5f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(rightSceneName);
    }
}
