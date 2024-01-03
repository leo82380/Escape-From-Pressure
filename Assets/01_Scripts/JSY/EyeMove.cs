using UnityEngine;

public class EyeMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 lookDir;

    private void LateUpdate()
    {
        lookDir = target.position - transform.position;
        lookDir.Normalize();
        var look = Quaternion.LookRotation(lookDir).eulerAngles;
        print(look.x + " " + look.y);
        var x = Mathf.Clamp(look.x, -3, 3);
        var y = Mathf.Clamp(look.y, -10, 10);
        transform.rotation = Quaternion.Euler(x, y, 0);
    }
}
