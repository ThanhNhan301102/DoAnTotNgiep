using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsWeapon : MonoBehaviour
{
    //[SerializeField] private int maxWeapon;
    [SerializeField] private List<GameObject> weaponPrefab;
    private int count;
    void Start()
    {
        InvokeRepeating("RandomWeapon", 1, 5);
    }

    private void RandomWeapon()
    {
        float x = Random.Range(-20f, 20f);
        float y = Random.Range(-20f, 20f);
        Vector3 pos = new Vector3(x, y, 0);
        int wp = Random.Range(0, weaponPrefab.Count);
        GameObject newWeapon = Instantiate(weaponPrefab[wp], pos, Quaternion.identity);
    }
}
