using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.AI;
using Newtonsoft.Json.Serialization;
using Unity.Collections;
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
    private bool attacking1;
    private Animator animator;

    public AudioManager audioManager;

    public float damage => basedamage * EnemyStatsInstance.Instance.stats.damageMultiplier;
    public float attackCooldown => oldattackCooldown * EnemyStatsInstance.Instance.stats.attackSpeedUp;



    public bool isAttacking;
    public bool isMoving;
    // Start is called before the first frame update

    public void Awake()
    {
       AudioManager audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        EHealth = MaxEHealth;
         animator = GetComponent<Animator>();
        
    }
    void Update()
    {

        attacking1 = isAttacking;

        HealthBar.value = EHealth;
        HealthBar.maxValue = MaxEHealth;
        agent.destination = Playerpos.position;
        timer += Time.deltaTime;

        HealthBar.transform.LookAt(Playerpos);

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
                if(isAttacking == true)
                {
                    animator.SetBool("IsAttacking", true);
                    DealDamage();
                }
               
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
        audioManager.PlaySFX(audioManager.damaged);
    }   
    public void TakeDamage(float damage)
    {
        EHealth -= damage;
        audioManager.PlaySFX(audioManager.damage);
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