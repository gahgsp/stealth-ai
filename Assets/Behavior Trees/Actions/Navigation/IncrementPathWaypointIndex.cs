using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("IncrementPathWaypointIndex")]
public class IncrementPathWaypointIndex : GOAction
{
    [InParam("WaypointIndex")][OutParam("WaypointIndex")] public int waypointIndex { get; set; }
    
    private Transform[] _waypoints;
    
    public override void OnStart() => _waypoints = gameObject.GetComponent<PatrolPathController>().patrolPath.waypoints;

    public override TaskStatus OnUpdate()
    {
        if (waypointIndex + 1 <= _waypoints.Length - 1)
        {
            waypointIndex += 1;
            return TaskStatus.COMPLETED;
        }

        return TaskStatus.FAILED;
    }
}
