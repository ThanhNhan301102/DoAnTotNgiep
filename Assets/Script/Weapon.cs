using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector3 theScale;
    [SerializeField] private GameObject bulletPrefab;   //dan
    [SerializeField] private Transform firePos;   //noi khoi tao dan
    [SerializeField] private float timeBtwFire;     //thoi gian giua 2 vien dan ban ra
    private float timer;
    private float bulletForce = 9f;         //luc vien dan

    [SerializeField] private GameObject fireEffect;
    [SerializeField] private GameObject muzzle;

    [SerializeField] public int damage;
    public static int damagewp; //dam cua sung

    private void Start()
    {
        damagewp = damage;
        theScale = transform.localScale;
        timer = 0;
    }
    void Update()
    {
        RotateRun();
        timer -= Time.deltaTime;
        if (Input.GetMouseButton(1) && timer < 0)
        { //nhan chuot phai
            FireBullet();
        }
    }

    void RotateRun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //lay vi tri chuot
        mousePos.y += 0.25f;
       // mousePos.x -= 0.25f;

        Vector2 lookDir = mousePos - transform.position; //lay vector tu nhan vat sang vi tri chuot
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; //goc ban

        Quaternion rotation = Quaternion.Euler(0, 0, angle); //Quay sung       
        transform.rotation = rotation;
       
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) //lat lai khi quay sung     
            transform.localScale = new Vector3(theScale.x, theScale.y*-1, theScale.z);        
        else
            transform.localScale = new Vector3(theScale.x, theScale.y, theScale.z);

    }

    void FireBullet()
    {
        timer = timeBtwFire;
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);

        Instantiate(muzzle, firePos.position, transform.rotation, transform);   //khoi tao hieu ung
        Instantiate(fireEffect, firePos.position, transform.rotation, transform);
        

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
       
    }
}
