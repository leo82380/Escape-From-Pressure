using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureMaterial : MonoSingleton<PictureMaterial>
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
}
