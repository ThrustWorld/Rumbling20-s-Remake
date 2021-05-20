using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;
    public AudioClip CarEngine;
    public AudioClip OtherCar;
    public AudioClip[] buche;
    public AudioClip MotoreRotto;
    public AudioClip partenza;
    public AudioClip riduzioneVelocità;
    public AudioClip repair;
    public AudioClip schianto;
    public AudioClip transitionEngineRotto;

    int random;


    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        random = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayEngine()
    {
        AudioSource.PlayOneShot(CarEngine,1f);
    }
    public void PlayOtherCar()
    {
        AudioSource.PlayOneShot(OtherCar);
    }
    public void PlayBuche()
    {
        AudioSource.PlayOneShot(buche[random],1);
    }
    public void PlayEngineRotto()
    {
        AudioSource.PlayOneShot(MotoreRotto,1);
    }
    public void PlayPartenza()
    {
        AudioSource.PlayOneShot(partenza,1);
    }
    public void PlayRiduzioneVelocità()
    {
        AudioSource.PlayOneShot(riduzioneVelocità);
    }
    public void PlayRepair()
    {
        AudioSource.PlayOneShot(repair);
    }
    public void PlaySchianto()
    {
        AudioSource.PlayOneShot(schianto,1);
    }
    public void PlayTransition()
    {
        AudioSource.PlayOneShot(transitionEngineRotto);
    }
}
