using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    Transform player;
    
    Rigidbody2D rb;
    public float speed = 2.5f;
    Boss boss;
    public float attackRange = 5;
    private float secondsCount;
    private float runCounter = 5;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
       

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (runCounter <= secondsCount)
            {
            speed = Random.Range(3f, 15.0f);
            secondsCount = 0f;
            runCounter = Random.Range(1f, 5.0f);
            //Debug.Log("Setting move Speed to : "+ speed);
            }
        secondsCount += Time.deltaTime;  

        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

       

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }

    
}
