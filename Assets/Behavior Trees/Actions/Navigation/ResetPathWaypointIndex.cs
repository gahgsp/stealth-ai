using System.Collections;
using System.Collections.Generic;
using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("ResetPathWaypointIndex")]
public class ResetPathWaypointIndex : GOAction
{
    [InParam("WaypointIndex")][OutParam("WaypointIndex")] public int waypointIndex { get; set; }

    public override void OnStart()
    {
        waypointIndex = 0;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }
}
