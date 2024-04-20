using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDeath : MonoBehaviour
{
    [SerializeField] private AudioSource auDeath;
    void Start()
    {
        auDeath.Play();
    }

    
}
