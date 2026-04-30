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
    private void Update()
    {
        if (_system != null && _system.hasPower)
        {
            _animator.SetBool("DoorOpen", true);
        }
    }
}
