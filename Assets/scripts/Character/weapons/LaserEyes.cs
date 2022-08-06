using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyes : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public LayerMask missMe;
    // Start is called before the first frame update


    public void LasrRasr()
    {
        SoundManager.PlaySound("zap");
        Debug.Log("zaaaaaaaaaaaaaaaaaaaaaap");
        StartCoroutine(ShootLaser());
    }
    public IEnumerator ShootLaser()
    {

       RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, 1000, ~missMe);
        if (hitInfo)
        {

            genericBadie enemy = hitInfo.transform.GetComponent<genericBadie>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Boss boss = hitInfo.transform.GetComponent<Boss>();
            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            Debug.Log(hitInfo.transform.name);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, (firePoint.position));
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right*100);
        }
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.2f);

        lineRenderer.enabled = false;

    }
 
    
}
