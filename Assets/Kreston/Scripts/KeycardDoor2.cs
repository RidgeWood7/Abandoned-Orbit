using UnityEngine;

public class KeycardDoor2 : MonoBehaviour
{
    #region System Setting
    private CollectionSystem _system;

    private void Start()
    {
        _system = FindFirstObjectByType<CollectionSystem>();
    }
    #endregion


}
