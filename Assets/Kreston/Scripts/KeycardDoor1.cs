using UnityEngine;

public class KeycardDoor1 : MonoBehaviour
{
    #region System Setting
    private CollectionSystem _system;

    private void Start()
    {
        _system = FindFirstObjectByType<CollectionSystem>();
    }
    #endregion

    private bool canOpen;
    [SerializeField] private Animator _animator;

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
                _animator.SetBool("Open", true);
            }
        }
    }
}
