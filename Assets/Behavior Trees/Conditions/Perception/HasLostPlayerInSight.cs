using BBUnity.Conditions;
using Pada1.BBCore;
using UnityEngine;

[Condition("HasLostPlayerInSight")]
public class HasLostPlayerInSight : GOCondition
{
    [InParam("PlayerLastPosition")] public Vector3 playerLastPosition;

    public override bool Check() => playerLastPosition != Vector3.zero;
}
