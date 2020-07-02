using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;

[Action("ResetPathWaypointIndex")]
public class ResetPathWaypointIndex : GOAction
{
    [InParam("WaypointIndex")][OutParam("WaypointIndex")] public int waypointIndex { get; set; }

    public override void OnStart() => waypointIndex = 0;
    
    public override TaskStatus OnUpdate() => TaskStatus.COMPLETED;
}
