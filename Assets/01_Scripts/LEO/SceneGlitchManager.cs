using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlitchManager : MonoSingleton<SceneGlitchManager>
{
    [SerializeField] private Material material;
    
    protected override void Awake()
    {
        base.Awake();
    }
    
    public void Glitch(float noiseAmount, float glitchStrength, float scanLineStrength)
    {
        material.SetFloat("_NoiseAmount", noiseAmount);
        material.SetFloat("_GlitchStrenght", glitchStrength);
        material.SetFloat("_ScanLineStrenght", scanLineStrength);
    }
    
}