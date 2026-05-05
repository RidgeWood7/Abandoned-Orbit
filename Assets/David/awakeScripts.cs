using UnityEngine;

public class awakeScripts : MonoBehaviour
{
    character_movement player;
    PlayerStatsInstance statsInstance;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<character_movement>();
                statsInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsInstance>();
        
    }
}
