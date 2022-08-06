using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtlePower : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject[] prefabs;

    public Vector2[] turtleSpeed;
    private bool canShoot = true;

    //public bool attacking = false;

    public void Shoot()
    {
        SoundManager.PlaySound("tnmt");
        GameObject Left = (GameObject)Instantiate(prefabs[0], firePoints[0].position, transform.rotation);
        Left.GetComponent<Rigidbody2D>().velocity = turtleSpeed[0];

        GameObject Right = (GameObject)Instantiate(prefabs[1], firePoints[1].position, transform.rotation);
        Right.GetComponent<Rigidbody2D>().velocity = turtleSpeed[1];

        GameObject Up = (GameObject)Instantiate(prefabs[2], firePoints[2].position, transform.rotation);
        Up.GetComponent<Rigidbody2D>().velocity = turtleSpeed[2];

        GameObject Down = (GameObject)Instantiate(prefabs[3], firePoints[3].position, transform.rotation);
        Down.GetComponent<Rigidbody2D>().velocity = turtleSpeed[3];

    }

    // Update is called once per frame

}
