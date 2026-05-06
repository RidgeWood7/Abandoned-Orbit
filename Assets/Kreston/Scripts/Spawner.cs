using UnityEngine;

public class Spawner : MonoBehaviour
{
   public void Spawn(GameObject Enemy)
    {
        Instantiate(Enemy,transform.position,Quaternion.identity);
        //Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
