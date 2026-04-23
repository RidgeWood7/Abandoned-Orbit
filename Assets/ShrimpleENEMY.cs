using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
public class ShrimpleENEMY : MonoBehaviour
{
    public Transform Playerpos;
    public Slider HealthBar;
    public float MaxEHealth;
    public float EHealth;
    UnityEngine.AI.NavMeshAgent agent;
    public bool isDead = false;
    private float timer;
    public float basedamage;
    [SerializeField] private float oldattackCooldown;

    public float damage => basedamage * EnemyStats.instance.damageMultiplier;
    public float attackCooldown => oldattackCooldown + EnemyStats.instance.attackSpeedUp;



    public bool isAttacking;
    public bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        EHealth = MaxEHealth;
    }
    void Update()
    {
     


        HealthBar.value = EHealth;
        HealthBar.maxValue = MaxEHealth;
        agent.destination = Playerpos.position;
        timer += Time.deltaTime;


    }
    private void OnTriggerStay(Collider collision)
    {
         //collison and attacking
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
            if (timer >= attackCooldown)
            {
                Debug.Log("Collided with player");
                isAttacking = true;
                DealDamage(); 
               
                timer = 0f; 
              
            }
           

        }
        else
        {
            isAttacking = false;
        }
     
    }
  

    public void DealDamage()
    {
       character_movement player = FindFirstObjectByType<character_movement>();
        player.TakeDamage(damage);
    }   
    public void TakeDamage(float damage)
    {
        EHealth -= damage;
        if (EHealth <= 0)
        {
            isDead = true;
            Die();

        }
    }
    void Die()
    {
        // Play death animation and/or effects here

        Destroy(gameObject);
        
    }
}