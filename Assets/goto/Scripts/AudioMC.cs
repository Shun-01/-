using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMC : MonoBehaviour
{
    private AudioSource _audiosOwn;

    [SerializeField]
    private AudioClip _clipExp;

    // Start is called before the first frame update
    void Start()
    {
        _audiosOwn=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ”š”­‰¹
    /// </summary>
    public void SoundExp()
    {
        _audiosOwn.PlayOneShot(_clipExp);
    }
}
