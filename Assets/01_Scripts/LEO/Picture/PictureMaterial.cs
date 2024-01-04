using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureMaterial : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private MeshRenderer _meshRenderer;
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public void ChangeMaterial(int _materialNumber)
    {
        _meshRenderer.material = _materials[_materialNumber];
    }

    public IEnumerator ChangeAllMaterial()
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _meshRenderer.material = _materials[i];
            yield return new WaitForSeconds(0.5f);
        }
    }
}
