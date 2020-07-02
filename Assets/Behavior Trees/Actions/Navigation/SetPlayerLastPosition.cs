using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("SetPlayerLastPosition")]
public class SetPlayerLastPosition : GOAction
{
    [InParam("Player")] public GameObject player;

    [OutParam("PlayerLastPosition")] public Vector3 playerLastPosition { get; set; }

    public override void OnStart() => playerLastPosition = player.transform.position;
    public override TaskStatus OnUpdate() => TaskStatus.COMPLETED;
}
