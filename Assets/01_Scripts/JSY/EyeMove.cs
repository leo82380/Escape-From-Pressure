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
        
        if (look.x > 0 && look.x < 180 && look.x > 3)
        {
            look.x = 3;
        }
        else if (look.x < 360 && look.x > 180 && look.x < 357)
        {
            look.x = 357;
        }
        
        if (look.y > 0 && look.y < 180 && look.y > 30)
        {
            look.y = 30;
        }
        else if (look.y < 360 && look.y > 180 && look.y < 330)
        {
            look.y = 330;
        }
        transform.rotation = Quaternion.Euler(look.x, look.y, 0);
    }
}
