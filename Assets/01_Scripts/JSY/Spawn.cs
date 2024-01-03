using UnityEngine;
public class Spawn : MonoBehaviour
{
    private void Awake() => FindObjectOfType<PlayerController>().transform.position = transform.position;
}