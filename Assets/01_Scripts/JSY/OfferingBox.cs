using System.Collections;
using UnityEngine;
using DG.Tweening;
public class OfferingBox : MonoBehaviour
{
    [SerializeField] private GameObject numberEnvelope;
    void Awake() => StartCoroutine(CoolTimeMove());
    IEnumerator CoolTimeMove()
    {
        yield return new WaitForSeconds(2f);
        transform.DOMoveY(5.7f, 2f);
    }

    public void MoveDown()
    {
        FindObjectOfType<Inventory>().InventoryImageDestroy(1);
        numberEnvelope.SetActive(true);
        transform.DOMoveY(8f- 5.7f, 2f);
    }
}