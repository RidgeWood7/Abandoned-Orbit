using UnityEngine;
using UnityEngine.Audio;

public class SetitngsPOPUP : MonoBehaviour
{
    private bool PauseSetting = true;
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

    public void Resume()
    {
        settingsMenu.SetActive(false);
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        Time.timeScale = 1f;
        PauseSetting = false;
    }
    void Pause()
    {
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        settingsMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseSetting = true;
    }
}
