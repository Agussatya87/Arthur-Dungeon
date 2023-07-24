using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip -----------")]
    public AudioClip background;
    public AudioClip uiclick;
    public AudioClip uiback;

    private void start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
