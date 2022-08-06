using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 20;
	public int enragedAttackDamage = 40;
	public LayerMask playerLayer;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	public Rigidbody2D rb;
	
	public Transform melePoint;
	public Vector2 hitForceV;
	public Vector2 hitForceVN;


	public void Attack()
	{
		hitForceVN.x = -hitForceV.x;
		hitForceVN.y = hitForceV.y;
		Debug.Log("Attacking");
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<HealthSystem >().TakeDamage(attackDamage);
			rb = colInfo.GetComponent<Rigidbody2D>();
			if (melePoint.position.x < rb.position.x)
			{
			
				rb.velocity = hitForceV;
			}
			else
			{
				
				rb.velocity = hitForceVN;
			}
		}

		
	}

	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<HealthSystem>().TakeDamage(enragedAttackDamage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}