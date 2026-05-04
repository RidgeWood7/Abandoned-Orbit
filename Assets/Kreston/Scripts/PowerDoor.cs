using UnityEngine;

public class PowerDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    #region System Setting
    private CollectionSystem _system;

    private void Start()
    {
        _system = FindFirstObjectByType<CollectionSystem>();
    }
    #endregion
    public AudioManager audioManager;
    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (_system != null && _system.hasPower)
        {
            audioManager.PlaySFX(audioManager.doorOpened);
            _animator.SetBool("DoorOpen", true);
        }
    }
}
