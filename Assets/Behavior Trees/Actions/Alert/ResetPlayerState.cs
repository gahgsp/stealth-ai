using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;

[Action("ResetPlayerState")]
public class ResetPlayerState : GOAction
{
    public override void OnStart()
    {
        gameObject.GetComponent<Enemy>().IsAlerted = false;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.COMPLETED;
    }
}
