using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("AlertTroops")]
public class AlertTroops: GOAction
{
    
    [InParam("Range", DefaultValue = 30f)] public float range;
    
    public override void OnStart()
    {
        AlertAllTroopsInRange();
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.FAILED;
    }

    private void AlertAllTroopsInRange()
    {
        var objectsInRange = Physics.OverlapSphere(gameObject.transform.position, range);
        for (var i = 0; i < objectsInRange.Length; i++)
        {
            var enemyScript = objectsInRange[i].GetComponent<Enemy>();
            if (enemyScript != null && !enemyScript.IsDead && !enemyScript.IsAlerted)
            {
                enemyScript.IsAlerted = true;
            } 
        }
    }
}