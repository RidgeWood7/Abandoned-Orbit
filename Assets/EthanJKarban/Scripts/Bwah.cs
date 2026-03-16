using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
public class Bwah : MonoBehaviour
{
    public AudioClip startClip;
    public AudioClip loopClip;
    

    public AudioMixerGroup mixer;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.outputAudioMixerGroup = mixer;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PlayMusicSequence());
    }
    IEnumerator PlayMusicSequence()
    {
        audioSource.clip = startClip;
        audioSource.loop = false;
        audioSource.Play();

        yield return new WaitForSeconds(startClip.length);

        audioSource.clip = loopClip;
        audioSource.loop = true;
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
