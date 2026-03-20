using UnityEngine;
using UnityEngine.Audio;

public class SetitngsPOPUP : MonoBehaviour
{
    private bool PauseSetting = false;
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
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        Time.timeScale = 1f;
        PauseSetting = false;
    }
    void Pause()
    {
        settingsMenu.SetActive(true);
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        Time.timeScale = 0f;
        PauseSetting = true;
    }
}
