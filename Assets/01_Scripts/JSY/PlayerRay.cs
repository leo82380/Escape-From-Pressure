using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    Camera mainCamera;

    public bool _canTyping;
    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.CompareTag("InteractionObject"))
            {
                var dis = Vector3.Distance(transform.position, hit.collider.transform.position);
                Debug.Log("Ãæµ¹ÇÔ");
                if (hit.collider != null && dis <= 3f)
                {
                    FindObjectOfType<PlayerInteraction>().SetActiveInteractionPanel(true, hit.collider.GetComponent<PlayerCheck>()._interactionText);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        hit.collider.GetComponent<PlayerCheck>().Typing();
                    }
                }
            }
            else
            {
                FindObjectOfType<PlayerInteraction>().SetActiveInteractionPanel(false);
            }
        }
    }
}
