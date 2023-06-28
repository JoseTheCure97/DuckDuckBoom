using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private UIManager manager;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && !audioSource.isPlaying)
        {
            audioSource.Play();
            manager.ShowDuckCounter();
        }
    }
}
