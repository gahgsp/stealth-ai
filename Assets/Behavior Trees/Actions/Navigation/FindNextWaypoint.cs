using System.Collections;
using System.Collections.Generic;
using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("FindNextWaypoint")]
public class FindNextWaypoint : GOAction
{
    [InParam("WaypointIndex")] public int waypointIndex;

    [OutParam("NextWaypoint")] public Vector3 nextWaypoint { get; set; }

    public override void OnStart()
    {
        nextWaypoint = gameObject.GetComponent<PatrolPathController>().patrolPath.waypoints[waypointIndex].position;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }
}
