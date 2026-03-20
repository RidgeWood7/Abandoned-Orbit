using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float lifetime = 5f;
    public Collider bulletCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}