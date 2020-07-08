using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private float _turnSpeed = 3f;
    
    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        transform.Rotate(horizontal * _turnSpeed * Vector3.up);
    }
}
