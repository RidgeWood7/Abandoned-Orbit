using UnityEngine;
using UnityEngine.UIElements;

public class WinScene : MonoBehaviour
{
    public AudioManager audioManager;

    public VisualElement ui;

    public Button WinButton;

    public string MainMenuName = "MainMenu";

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        ui = GetComponent<UIDocument>().rootVisualElement;

    }

    private void OnEnable()
    {
        WinButton = ui.Q<Button>("Win");
        WinButton.clicked += OnWinButtonClicked;

    }

    private void OnWinButtonClicked()
    {
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1.5f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(MainMenuName);

    }
}
