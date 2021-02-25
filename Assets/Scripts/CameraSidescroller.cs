using UnityEngine;

public class CameraSidescroller : MonoBehaviour
{
    public float initialVerticalPosition = 0;
    public float verticalOffsetTrigger = 100;
    //assigned to any Unity object you want to track
    public Transform target;

    //adjust speed of camera
    public float cameraSpeed;

    //use z axis to zoom in and out from object
    public Vector3 offset;

    //called on Physics engine update (multiple times per frame)
    private void FixedUpdate()
    {
        followMovement();
    }

    private void followMovement()
    {
        Vector3 desiredPosition = offset + new Vector3(target.position.x, 0, 0);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);
        transform.position = smoothedPosition;
    }
    private float determineVerticalPosition()
    {
        if (target.position.y > verticalOffsetTrigger)
        {
            return verticalOffsetTrigger;
        }
        else
        {
            return initialVerticalPosition;
        }
    }
}
