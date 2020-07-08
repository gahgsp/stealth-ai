using BBUnity.Conditions;
using Pada1.BBCore;
using UnityEngine;

[Condition("IsAlerted")]
public class IsAlerted: GOCondition
{
    
    public override bool Check()
    {
        return gameObject.GetComponent<Enemy>().IsAlerted;
    }
}
