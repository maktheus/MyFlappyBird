using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static AudioClip jumpSound,dieSound ,hitSound, pointSound,swooshingSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {

        jumpSound = Resources.Load<AudioClip>("sfx_wing");
        dieSound = Resources.Load<AudioClip>("sfx_die");
        hitSound = Resources.Load<AudioClip>("sfx_hit");
        pointSound = Resources.Load<AudioClip>("sfx_point");
        swooshingSound = Resources.Load<AudioClip>("sfx_swooshing");

        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public static void PlaySound (string clip)
        {
            switch (clip)
            {
                case "jump":
                audioSrc.PlayOneShot (jumpSound);
                break;
                case "die":
                audioSrc.PlayOneShot (dieSound);
                break;
                case "hit":
                audioSrc.PlayOneShot (hitSound);
                break;
                case "point":
                audioSrc.PlayOneShot (pointSound);
                break;
                case "swooshing":
                audioSrc.PlayOneShot (swooshingSound);
                break;
                
            }
        }

}
