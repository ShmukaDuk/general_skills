using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiney : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public CharacterController2D characterController2D;
    public GameObject chef;
    float runSpeedInit;
    float jumpForceInit;
    float doubleJumpForcenit;
    Vector3 ChefScaleInit;
    public bool test;

    public void SmallPower()
    {
        StartCoroutine(StartSmallMan());
    }

    // Start is called before the first frame update
    public void Small()
    {
        ChefScaleInit = chef.transform.localScale;
        runSpeedInit = playerMovement.runSpeed;
        jumpForceInit = characterController2D.m_JumpForce;
        doubleJumpForcenit = characterController2D.doubleJumpForce;

        playerMovement.runSpeed = 400;
        characterController2D.m_JumpForce = 2000;
        characterController2D.doubleJumpForce = 40;
        chef.transform.localScale = new Vector3(0.5f, 0.5f, 0);

    }
    public void Big()
    {
        playerMovement.runSpeed = runSpeedInit;
        characterController2D.m_JumpForce = jumpForceInit;
        characterController2D.doubleJumpForce = doubleJumpForcenit;
        chef.transform.localScale = ChefScaleInit;
    }
    IEnumerator StartSmallMan()
    {
        Small();
        yield return new WaitForSeconds(5);
        Big();      

    }


}
