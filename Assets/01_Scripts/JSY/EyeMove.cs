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
        var x = Mathf.Clamp(look.x, -3, 357);
        var y = Mathf.Clamp(look.y, -10, 350);
        transform.rotation = Quaternion.Euler(x, y, 0);
    }
}
