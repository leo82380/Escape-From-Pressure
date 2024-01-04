using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    [SerializeField] private Light[] lights;
    public IEnumerator OnOffLight()
    {
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < lights.Length; i++) lights[i].enabled = false;
            yield return new WaitForSeconds(0.3f);
            for (int i = 0; i < lights.Length; i++) lights[i].enabled = true;
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < lights.Length; i++) lights[i].enabled = false;
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < lights.Length; i++) lights[i].enabled = true;
        for (int i = 0; i < lights.Length; i++) lights[i].color = Color.red;
        yield return null;
    }
}
