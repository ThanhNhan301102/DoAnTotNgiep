using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpR1 : MonoBehaviour
{
     private GameObject r1;
     private GameObject r2;
     private GameObject r3;
     private GameObject player;
     private List<GameObject> weapon;

    [SerializeField] private int index;

    private void Start()
    {
        player = GameObject.Find("Player");
        r1 = player.transform.Find("weaponR1").gameObject;
        r2 = player.transform.Find("weaponR2").gameObject;
        r3 = player.transform.Find("weaponR3").gameObject;

        weapon = new List<GameObject>();
        weapon.Add(r1);
        weapon.Add(r2);
        weapon.Add(r3);
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player e = collision.GetComponent<Player>();
        if(e != null)
        {
            for(int i=0; i<weapon.Count; i++)
            {
                if (i == index)
                    weapon[i].SetActive(true);
                else
                    weapon[i].SetActive(false);
            }           
            Destroy(gameObject);
        }
    }

}
