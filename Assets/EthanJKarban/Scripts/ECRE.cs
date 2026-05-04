using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ECRE : MonoBehaviour
{
    //public VisualElement SettingsPannel;

    public AudioManager audioManager;

    public VisualElement ui;

    public Button ExitButton;
    public Button LeftButton;
    

    public string sceneName = "Credits";
    public string creditsSceneName = "Credits";
    public string leftSceneName = "CD";
    

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


}
