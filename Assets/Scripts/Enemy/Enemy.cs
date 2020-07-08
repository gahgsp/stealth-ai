using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Material _patrolMaterial;
    [SerializeField] private Material _alertMaterial;
    
    private bool _isDead;
    private bool _isAlerted;

    private void Update()
    {
        GetComponent<MeshRenderer>().material = _isAlerted ? _alertMaterial : _patrolMaterial;
    }

    public void Kill()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<BehaviorExecutor>().enabled = false;
        GetComponent<PatrolPathController>().enabled = false;
        // TODO: Refactor the lines below!
        transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        transform.position = new Vector3(transform.position.x, 0.65f, transform.position.z);
        _isDead = true;
    }

    public bool IsDead => _isDead;

    public bool IsAlerted
    {
        get => _isAlerted;
        set => _isAlerted = value;
    }
}
