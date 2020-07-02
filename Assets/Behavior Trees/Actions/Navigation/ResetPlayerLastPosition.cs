using System.Collections;
using System.Collections.Generic;
using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("ResetPlayerLastPosition")]
public class ResetPlayerLastPosition : GOAction
{
    [InParam("PlayerLastPosition")] [OutParam("PlayerLastPosition")] public Vector3 playerLastPosition { get; set; }

    public override void OnStart()
    {
        playerLastPosition = Vector3.zero;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }
}
