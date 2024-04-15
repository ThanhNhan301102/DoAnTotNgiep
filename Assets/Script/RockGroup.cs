using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGroup : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerHealth e = collision.GetComponent<PlayerHealth>();
        if(e != null)
        {
            e.Hit(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerHealth e = collision.GetComponent<PlayerHealth>();
        if (e != null)
        {
            e.UnHit();
        }
    }

}
