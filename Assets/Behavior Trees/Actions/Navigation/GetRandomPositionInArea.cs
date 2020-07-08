using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("GetRandomPositionInArea")]
public class GetRandomPositionInArea : GOAction
{
    [InParam("CenterPosition")] public Vector3 centerPosition;

    [OutParam("RandomPositionInArea")] public Vector3 randomPositionInArea { get; set; }

    public override void OnStart()
    {
        GenerateRandomPosition();
    }

    public override TaskStatus OnUpdate() => TaskStatus.COMPLETED;

    private void GenerateRandomPosition()
    {
        if (centerPosition == null || centerPosition == Vector3.zero)
        {
            centerPosition = gameObject.transform.position;
        }
        
        randomPositionInArea = new Vector3(
            Random.Range(centerPosition.x - 2, centerPosition.x + 2),
            centerPosition.y,
            Random.Range(centerPosition.z - 2, centerPosition.z + 2));
    }
}
