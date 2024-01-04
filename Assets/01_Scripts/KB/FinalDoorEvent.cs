using UnityEngine;

public class FinalDoorEvent : MonoBehaviour
{
    [SerializeField] private float inTime;
    [SerializeField] private int flagCount = 85;
    
    private bool isClear = false;
    
    private float time = 0;
    private int myCount = 0;

    public void DoorEvent() // DoorEvent
    {
        while (time <= inTime)
        {
            time += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space)) myCount++;
            if (myCount >= flagCount)
            {
                isClear = true;
                return;
            }
        }
        
        if (myCount >= flagCount) isClear = true;
        else isClear = false;
    }

    public bool GetIsClear() => isClear;


}
