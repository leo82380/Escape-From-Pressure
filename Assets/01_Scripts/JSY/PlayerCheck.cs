using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField] private string _interactionText;

    private Transform playerTransform;
    private bool canPanel;
    private void Update()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
        Vector3 transformm = transform.position - playerTransform.position;
        if (transformm.x < 2f && transformm.x > -2f && transformm.z < 2f && transformm.z > -2f)
        {
            FindObjectOfType<PlayerInteraction>().SetActiveInteractionPanel(true, _interactionText);
            canPanel = false;
        }
        else
        {
            if (canPanel) return;
            else
            {
                canPanel = true;
            }
            FindObjectOfType<PlayerInteraction>().SetActiveInteractionPanel(false, _interactionText);
        }
    }

    
}
