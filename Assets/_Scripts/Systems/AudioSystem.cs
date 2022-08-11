using UnityEngine;


// basic audio system
public class AudioSystem : Singleton<AudioSystem>
{
    public void PlaySound(AudioSource source,AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void PlayOneShot(AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}