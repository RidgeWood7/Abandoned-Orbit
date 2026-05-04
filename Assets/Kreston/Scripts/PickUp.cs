using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public List<string> item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CollectionSystem system))
        {
            foreach (var item in item)
            {
                if (!system.collection.Contains(item))
                {
                    system.collection.Add(item);
                }
            }
            
            Destroy(gameObject);
        }
    }
}
