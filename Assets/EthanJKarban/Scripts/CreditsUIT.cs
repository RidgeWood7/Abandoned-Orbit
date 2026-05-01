using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class CreditsUIT : MonoBehaviour
{
    public AudioManager audioManager;

    public Button CK;
    public Button CF;
    public Button CD;
    public Button CE;
    public Button MainMenuButton;

    public VisualElement ui;

    public string KrestonCredits = "CK";
    public string FinnCredits = "CF"; 
    public string DavidCredits = "CD";
    public string EthanCredits = "CE";
    public string MainMenu = "Outdoors";


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        ui = GetComponent<UIDocument>().rootVisualElement;
    }
    private void OnEnable()
    {
        CK = ui.Q<Button>("Kreston");
        CK.clicked += CKC;

        CF = ui.Q<Button>("Finn");
        CF.clicked += CFC;

        CD = ui.Q<Button>("David");
        CD.clicked += CDC;

        CE = ui.Q<Button>("Ethan");
        CE.clicked += CEC;

        MainMenuButton = ui.Q<Button>("Exit");
        MainMenuButton.clicked += MMC;

    }

    private void CKC()
    {
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(KrestonCredits);
    }
    private void CFC()
    {
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(FinnCredits);
    }
    private void CDC()
    {
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(DavidCredits);
    }
    
    private void CEC()
    {
        audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(EthanCredits);
    }
    private void MMC()
    {
               audioManager.PlaySFX(audioManager.Button);
        Time.timeScale = 1f;
        FindFirstObjectByType<LevelLoaderTemplate>().LoadLevelByName(MainMenu);
    }
}

