using BBUnity.Conditions;
using Pada1.BBCore;
using UnityEngine;

[Condition("SawDeadTroop")]
public class SawDeadTroop : GOCondition
{

    [InParam("Range", DefaultValue = 10f)] public float range;
    [InParam("FieldOfView", DefaultValue = 45f)] public int fieldOfView;
    [InParam("ViewDistance", DefaultValue = 10f)] public int viewDistance;
    
    public override bool Check()
    {
        var enemyScript = gameObject.GetComponent<Enemy>();
        
        // If the troop is already alerted, we do not need to alert it and the others again.
        if (enemyScript.IsAlerted) return false;
        
        var objectsInRange = Physics.OverlapSphere(gameObject.transform.position, range);
        for (var i = 0; i < objectsInRange.Length; i++)
        {
            var enemyScriptFromObjectInRange = objectsInRange[i].gameObject.GetComponent<Enemy>();
            
            // Checks if the object in range is an enemy and is dead.
            if (enemyScriptFromObjectInRange != null && enemyScriptFromObjectInRange.IsDead)
            {
                RaycastHit hit;
                
                // Gets the direction from the current dead troop position to this NPC position.
                var raycastDirection = objectsInRange[i].gameObject.transform.position - gameObject.transform.position;
        
                // Compares the angle between the NPC's forward vector with the raycast direction calculated above.
                if (Vector3.Angle(raycastDirection, gameObject.transform.forward) < fieldOfView) // TODO: Create input for fov!
                {
                    // Checks if the dead body is visible to the NPC within the view distance.
                    if (Physics.Raycast(gameObject.transform.position, raycastDirection, out hit, viewDistance)) // TODO: Create input for maxDistance!
                    {
                        var collidedObjectEnemyScript = hit.collider.gameObject.GetComponent<Enemy>();
                        if (collidedObjectEnemyScript != null && collidedObjectEnemyScript.IsDead)
                        {
                            collidedObjectEnemyScript.Decompose();
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
