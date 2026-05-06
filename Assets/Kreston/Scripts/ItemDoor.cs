using UnityEngine;
using UnityEngine.Events;

public class ItemDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private AudioManager audioManager;
    #region System Setting
    private CollectionSystem _system;

    private void Start()
    {
        _system = FindFirstObjectByType<CollectionSystem>();
        Debug.Log("Collection System found: " + (_system != null));
    }
    #endregion

    private bool _isOpened;

    public string itemToOpen;

    public UnityEvent onNoItem;
    public UnityEvent onNoItemClose;
    public UnityEvent onOpen;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _system != null)
        {
            if (_system.collection.Contains(itemToOpen) && !_isOpened)
            {
                if (audioManager != null)
                {
                    audioManager.PlaySFX(audioManager.doorOpened);
                }
                _animator.SetBool("DoorOpen", true); 
                onOpen.Invoke();
                _isOpened = true;
            }
            else if (!_system.collection.Contains(itemToOpen))
            {
                onNoItem.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onNoItemClose.Invoke();
    }
}
