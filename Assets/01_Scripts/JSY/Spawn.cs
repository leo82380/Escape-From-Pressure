using System.Collections;
using UnityEngine;
public class Spawn : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<PlayerController>().transform.position = transform.position;
        StartCoroutine(CoolTime());
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(FindObjectOfType<TV_MaterialController>().WhileAnime());
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(FindObjectsOfType<PictureMaterial>()[i].ChangeAllMaterial());
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(FindObjectOfType<LightOnOff>().OnOffLight());
    }
}