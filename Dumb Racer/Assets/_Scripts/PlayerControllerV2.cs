using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV2: MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public float rotationSpeed;
    public GameObject Player1;
    public GameObject Spawn1;
    private Transform myTrans;


    // Update is called once per frame
    void FixedUpdate()
    {

        if (gameObject.tag == "Player1")
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.forward * -rotationSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(gameObject.transform.up * speed);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(gameObject.transform.up * -speed);
            }
        }
        if (gameObject.tag == "Player2")
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.forward * -rotationSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(gameObject.transform.up * speed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(gameObject.transform.up * -speed);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        // Respawning the player when OUT OF BOUNDS
        if (coll.gameObject.tag == "OB")
        {
            Instantiate(Player1, Spawn1.transform.position, Spawn1.transform.rotation);
            Destroy(gameObject);
            //Reset();
        }

        // Adding force to simulate collisions of players
        //if (coll.gameObject.tag == "Player3")
        //{
        //    Vector3 direction = (transform.position - coll.transform.position);
        //    Player3.GetComponent<Rigidbody2D>().AddForce(direction * 20);
        //}

    }
}
