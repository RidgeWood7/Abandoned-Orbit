using UnityEngine;

public class KeycardDoor1 : MonoBehaviour
{
    public AudioManager audioManager;
    [SerializeField] private Animator _animator;
    #region System Setting
    private CollectionSystem _system;

    private void Start()
    {
        _system = FindFirstObjectByType<CollectionSystem>();
    }
    #endregion

    private bool canOpen;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (_system != null && _system.hasKeycard1) //<------
        {
            canOpen = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _system != null && _system.hasKeycard1) //<------
        {
            if (canOpen)
            {
                audioManager.PlaySFX(audioManager.doorOpened);
                _animator.SetBool("DoorOpen", true); 
            }
        }
    }
}
