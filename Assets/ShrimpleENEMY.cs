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
        if (EHealth < 0  )
        {
            isDead = true;
            Destroy(gameObject);

        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        //collison and attacking
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

    }
}