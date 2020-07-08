using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [Header("State Materials")]
    [SerializeField] private Material _patrolMaterial;
    [SerializeField] private Material _alertMaterial;
    
    // Cached references.
    private BehaviorExecutor _behaviorExecutor;
    private MeshRenderer _meshRenderer;
    private NavMeshAgent _navMeshAgent;
    private PatrolPathController _patrolPathController;

    private void Awake()
    {
        _behaviorExecutor = GetComponent<BehaviorExecutor>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _patrolPathController = GetComponent<PatrolPathController>();
    }

    private void Update()
    {
        _meshRenderer.material = IsAlerted ? _alertMaterial : _patrolMaterial;
    }

    public void Kill()
    {
        DisableComponents();
        RotateBody();
        IsDead = true;
    }

    private void DisableComponents()
    {
        _navMeshAgent.enabled = false;
        _behaviorExecutor.enabled = false;
        _patrolPathController.enabled = false;
    }

    private void RotateBody()
    {
        // TODO: Refactor the lines below!
        transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        transform.position = new Vector3(transform.position.x, 0.65f, transform.position.z);
    }

    public void Decompose()
    {
        Destroy(gameObject);
    }

    public bool IsDead { get; private set; }

    public bool IsAlerted { get; set; }
}
