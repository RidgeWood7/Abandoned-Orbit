using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    public List<string> item;

    public UnityEvent onPickUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CollectionSystem system))
        {
            foreach (var item in item)
            {
                if (!system.collection.Contains(item))
                {
                    system.collection.Add(item);
                    onPickUp.Invoke();
                }
            }
            
            Destroy(gameObject);
        }
    }
}
