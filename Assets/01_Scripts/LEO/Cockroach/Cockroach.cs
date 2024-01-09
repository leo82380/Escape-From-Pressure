using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Cockroach : MonoBehaviour
{
    [SerializeField] private Image cockroach;
    
    private AudioSource cockroachAudio;
    private MeshRenderer _meshRenderer;
    

    private void Awake()
    {
        cockroachAudio = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public IEnumerator Rotate()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, -145), 1f);
        yield return new WaitForSeconds(1f);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, -135), 1f);
        
        yield return new WaitForSeconds(1f);
        cockroachAudio.Play();
        _meshRenderer.enabled = false;
        cockroach.transform.DOMove(new Vector3(1250, 750), 0.8f);
        yield return new WaitForSeconds(1.7f);
        cockroach.transform.DOMove(new Vector3(1250 * 2, 750 * 2), 0.3f);
    }
}
