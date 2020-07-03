using UnityEngine;
using UnityEngine.UI;

public class MeleeAttack : MonoBehaviour
{

    [SerializeField] private Text _attackText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAttack();
    }

    private void CheckAttack()
    {
        RaycastHit hit;
        Enemy enemyScript;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            enemyScript = hit.collider.gameObject.GetComponent<Enemy>();
            if (_attackText.enabled && Input.GetKeyDown(KeyCode.F))
            {
                enemyScript.Kill();
            }
        }
        else
        {
            enemyScript = null;
        }
        _attackText.enabled = enemyScript != null;
    }
}
