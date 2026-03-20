using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public LineRenderer line;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                line.SetPosition(1, new Vector3(0, 0, hit.distance));
            }
            
        }
        else
        {
            line.SetPosition(1, new Vector3(0, 0, 5000));

        }
    }


}
