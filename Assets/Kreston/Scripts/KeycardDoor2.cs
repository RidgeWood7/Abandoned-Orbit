using UnityEngine;

public class KeycardDoor2 : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    #region System Setting
    private CollectionSystem _system;

    private void Start()
    {
        _system = FindFirstObjectByType<CollectionSystem>();
    }
    #endregion

    private bool canOpen;

    private void Update()
    {
        if (_system != null && _system.hasKeycard2)
        {
            canOpen = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _system != null && _system.hasKeycard2)
        {
            if (canOpen)
            {
                _animator.SetBool("DoorOpen", true);
            }
        }
    }
}
