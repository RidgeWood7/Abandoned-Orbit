using UnityEngine;
using UnityEngine.Audio;

public class SetitngsPOPUP : MonoBehaviour
{
    private bool PauseSetting = false;
    public AudioManager audioManager;
    [SerializeField] AudioMixerGroup mixer;
    public AudioClip buttonSound;
    public GameObject settingsMenu;
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (PauseSetting)
        //    {
        //        Resume();
        //    }
        //    else
        //    {
        //        Pause();
        //    }
        //}
    }

    public void Decide()
    {
        audioManager.PlaySFX(audioManager.Button);
        if  (PauseSetting == true)
        {
            Resume();

        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseSetting = false;
    }
    void Pause()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseSetting = true;
    }
}
