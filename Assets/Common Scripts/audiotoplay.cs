using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotoplay : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip envrionmentsound;
    float lastplayed;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            audioplay();
        }
    }
    IEnumerator audioplay()
    {
        yield return new WaitForSeconds(2f);
    }
}
