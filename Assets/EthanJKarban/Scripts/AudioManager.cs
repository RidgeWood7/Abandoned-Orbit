using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource clickSource;
    [SerializeField] List<AudioClip> clickClips = new List<AudioClip>();

    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

    private void Awake()
    {
      if (instance == null)
      {
            instance = this;

            DontDestroyOnLoad(gameObject);
      }
      else
      {
            Destroy(gameObject);
      }
        VolumeLoader();
    }

    public void clickSFX()
    {
        AudioClip clip = clickClips[Random.Range(0, clickClips.Count)];

        clickSource.PlayOneShot(clip);
    }

    void VolumeLoader() // Volume saved in AudioSetting.cs
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(AudioSetting.MUSIC_MIXER, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(AudioSetting.SFX_MIXER, Mathf.Log10(sfxVolume) * 20);
    }

}
