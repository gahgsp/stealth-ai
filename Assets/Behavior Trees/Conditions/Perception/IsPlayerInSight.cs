using BBUnity.Conditions;
using Pada1.BBCore;
using UnityEngine;

[Condition("IsPlayerInSight")]
public class IsPlayerInSight : GOCondition
{
    [InParam("Player")] public GameObject player;

    [InParam("FieldOfView")] public int fieldOfView;

    [InParam("ViewDistance")] public int viewDistance;
    
    public override bool Check()
    {
        RaycastHit hit;
        
        // Gets the direction from the current player position to the NPC position.
        var raycastDirection = player.transform.position - gameObject.transform.position;
        
        // Compares the angle between the NPC's forward vector with the raycast direction calculated above.
        if (Vector3.Angle(raycastDirection, gameObject.transform.forward) < fieldOfView)
        {
            // Checks if the player is visible to the NPC within the view distance.
            if (Physics.Raycast(gameObject.transform.position, raycastDirection, out hit, viewDistance))
            {
                // The player is visible!
                if (hit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
