using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    [SerializeField] private float time;
    void Start()
    {
        Destroy(this.gameObject, time); //sau 2s huy dan
    }

    
}
