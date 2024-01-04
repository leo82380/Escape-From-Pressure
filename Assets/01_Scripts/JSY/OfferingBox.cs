using System.Collections;
using UnityEngine;
using DG.Tweening;
public class OfferingBox : MonoBehaviour
{
    void Awake() => StartCoroutine(CoolTimeMove());
    IEnumerator CoolTimeMove()
    {
        yield return new WaitForSeconds(30f);
        transform.DOMoveY(1.18f, 2f);
    }

    public void MoveDown()
    {
        transform.DOMoveY(-1.58f, 2f);
    }
}