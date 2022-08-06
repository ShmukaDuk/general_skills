using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pizzaCannon : MonoBehaviour
{
    private readonly System.Random _random = new System.Random();
    public Transform firePoint;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    private bool canShoot = true;
    public LayerMask HitMe;
    public float fireRate = 1000f;

    public int RandomNumber(int min, int max)
    {
        return _random.Next(min, max);
    }

    public IEnumerator shoot()
    {        
        if (canShoot)
        {
            int ramdNum = RandomNumber(1, 100);
            float waitTime = (ramdNum / fireRate);

            
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            canShoot = false;
            yield return new WaitForSeconds(waitTime);
            canShoot = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, 100, HitMe);
        if(hitInfo)
        {            
            HealthSystem player = hitInfo.transform.GetComponent<HealthSystem>();
            if (player)
            {                
                StartCoroutine(shoot());                
            }
        }
        

        
    }
}
