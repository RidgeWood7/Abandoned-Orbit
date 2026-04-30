using UnityEngine;

public class PowerDoor : MonoBehaviour
{
    #region System Setting
    private CollectionSystem _system;

    private void Start()
    {
        _system = FindFirstObjectByType<CollectionSystem>();
    }
    #endregion


}
