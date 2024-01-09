using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoSingleton<GameSceneManager>
{
    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Stage-2")
        {
            SceneGlitchManager.Instance.Glitch(0, 0, 1);
        }
        else
        {
            var fakeKey = FindObjectOfType<GetGameObject>().fakeKey.GetComponent<PlayerCheck>();
            Debug.Log(fakeKey.fakekey);
            if (fakeKey.fakekey)
            {
                StartCoroutine(Glitch());
            }
        }
    }

    private IEnumerator Glitch()
    {
        SceneGlitchManager.Instance.Glitch(100f, 100f, 0f);
        yield return new WaitForSeconds(3f);
        SceneGlitchManager.Instance.Glitch(0f, 0f, 1f);
    }
}
