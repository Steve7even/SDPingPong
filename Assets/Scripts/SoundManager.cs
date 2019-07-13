using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Mngr = null;

    public AudioClip goalBloop;
    public AudioClip lossBuzz;
    public AudioClip hitPaddle;
    public AudioClip winSound;
    public AudioClip hitWall;

    private AudioSource soundEffectAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (Mngr == null)
        {
            Mngr = this;
        } else if (Mngr != this)
        {
            Destroy(gameObject);
        }

        AudioSource[] sources = GetComponents<AudioSource>();
        foreach(AudioSource s in sources)
        {
            if (s.clip == null)
            {
                soundEffectAudio = s;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
