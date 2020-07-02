using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<BehaviorExecutor>().enabled = false;
        GetComponent<PatrolPathController>().enabled = false;
        // TODO: Refactor the lines below!
        transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        transform.position = new Vector3(transform.position.x, 0.65f, transform.position.z);
    }
}
