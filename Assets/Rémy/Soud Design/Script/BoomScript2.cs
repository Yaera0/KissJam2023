using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript2 : MonoBehaviour
{
    AudioSource m_AudioSource;
    [SerializeField] AudioClip boom;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        StartCoroutine("corBoom");
    }

    IEnumerator corBoom()
    {
        yield return new WaitForSeconds(0.4f);
        m_AudioSource.PlayOneShot(boom);
    }
}
