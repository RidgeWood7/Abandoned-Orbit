using Unity.VisualScripting;
using UnityEngine;

public class ApplyAmmoUp : MonoBehaviour
{
   
    public character_movement player;
   
    private void Awake()
    {
        player = FindFirstObjectByType<character_movement>();
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            player.AddComponent<Ammoup>();
            Destroy(gameObject);
            
        }
    }
}
