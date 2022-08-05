using UnityEngine;


// basic audio system
public class AudioSystem : Singleton<AudioSystem>
{
    [SerializeField] private AudioSource _musicSource; // Background music
    [SerializeField] private AudioSource _soundsSource; 

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void PlaySound(AudioClip clip, Vector3 pos, float vol = 1)
    {
        _soundsSource.transform.position = pos;
        PlaySound(clip,vol);
    }

    public void PlaySound(AudioClip clip, float vol = 1)
    {
        _soundsSource.PlayOneShot(clip,vol);
    }
}