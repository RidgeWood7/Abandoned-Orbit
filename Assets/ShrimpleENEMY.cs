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
    public float timer;
    public float damage;
    public float attackCooldown;



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
        


    }
    public void OnCollisionEnter(Collision collision)
    {

        
        //collison and attacking
        if (collision.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;
            if (timer >= attackCooldown)
            {
                DealDamage();
                timer = 0f;
            }
            isAttacking = true;

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
        if (EHealth < 0)
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