using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private AudioSource coinFX;
    private void Awake()
    {
        coinFX = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (coinFX != null) coinFX.Play();
        else
            Debug.Log("No coin fx audio source found for object: " + gameObject.name);
        this.gameObject.SetActive(false);

    }
}
