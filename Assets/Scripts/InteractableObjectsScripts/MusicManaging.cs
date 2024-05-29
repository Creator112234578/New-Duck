using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManaging : MonoBehaviour
{
    public AudioSource musicBox;
    public AudioClip ClipOst;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            musicBox.clip = ClipOst;
            musicBox.Play();
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            musicBox.clip = ClipOst;
            musicBox.Play();
        }
    }
}
