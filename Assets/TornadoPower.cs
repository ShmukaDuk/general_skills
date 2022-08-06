using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoPower : MonoBehaviour
{
    public Transform spawnNado;
    public GameObject prefab;
    public HealthSystem hp;

    public Animator animator;
    public CharacterController2D controller;
    public Rigidbody2D rb;
    Vector2 victor;
    public int spinDuration = 5;
    public GameObject TornadoHitBox;
    public CoolDown cooldown;

    public void StartSpin()
    {
        if (rb.velocity == victor)
        {
            cooldown.onPress();
            hp.invincable = true;
            controller.canMove = false;
            GameObject sword = (GameObject)Instantiate(prefab, spawnNado.position, spawnNado.rotation);
            StartCoroutine(DoAnimation());            
        }
        
    }
    IEnumerator DoAnimation()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("getSword");
        yield return new WaitForSeconds(1);
        TornadoHitBox.SetActive(true);
        controller.canMove = true;
        StartCoroutine(DoSpin());

    }
    IEnumerator DoSpin()
    {
        
        animator.SetTrigger("doSpin");
        yield return new WaitForSeconds(spinDuration);
        animator.SetTrigger("finSpin");
        TornadoHitBox.SetActive(false);
        controller.canMove = true;
        hp.invincable = false;

    }


    // Start is called before the first frame update

}
