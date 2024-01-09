using UnityEngine;

public class RadioAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    
    public bool isPlaying;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void PlayAudio()
    {
        _audio.Play();
        isPlaying = true;
    }
    
    public void StopAudio()
    {
        _audio.Stop();
        isPlaying = false;
    }
}
