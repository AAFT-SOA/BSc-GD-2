using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public Transform Target;

    private void LateUpdate()
    {
        Vector3 newPosition = Target.position;
        newPosition.y = Target.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, Target.eulerAngles.y, 0f);
    }
}
