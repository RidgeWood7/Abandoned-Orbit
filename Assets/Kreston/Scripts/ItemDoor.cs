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
    }
    #endregion

    public string itemToOpen;

    public UnityEvent onNoItem;
    public UnityEvent onNoItemClose;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && _system != null)
        {
            if (_system.collection.Contains(itemToOpen))
            {
                if (audioManager != null)
                {
                    audioManager.PlaySFX(audioManager.doorOpened);
                }
                _animator.SetBool("DoorOpen", true); 
            }
            else
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
