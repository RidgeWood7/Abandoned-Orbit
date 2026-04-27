using Unity.VisualScripting;
using UnityEngine;

public class ApplyDamageUp : MonoBehaviour
{
    public character_movement player;
    public void Awake()
    {
        player = FindFirstObjectByType<character_movement>();
    }


    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.AddComponent<DamageUp>(); // Add the DamageUp component to the player
            Destroy(gameObject); // Destroy the power-up after applying the effect
        }
    }
}
