using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float rotationSpeed;


    private Transform myTrans;
    private AudioSource [] audioSource;
    private AudioSource engMoving;
    private AudioSource engAccl;
    private AudioSource engIdle;
    private AudioSource engBrake;
    private AudioSource engReverse;
    private AudioSource getBomb;
    private AudioSource getItem;

    SpawnScript spawnScript;

    void Start()
    {

        audioSource = gameObject.GetComponents<AudioSource>();
        engIdle = audioSource[0];
        engAccl = audioSource[1];
        engMoving = audioSource[2];
        engBrake = audioSource[3];
        engReverse = audioSource[4];
        getBomb = audioSource[5];
        getItem = audioSource[6];
    }

    private void Update()
    {
        if (Input.GetKey("joystick button 0"))
        {
            Debug.Log(Input.GetJoystickNames() + "Controller In");
         
        }
    }

    private void Awake()
    {
        spawnScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnScript>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (gameObject.tag == "Player1")
        {
            Vector3 joyDirection = Vector3.zero;
            joyDirection.z = Input.GetAxis("Player1Steer");
            transform.Rotate(joyDirection * -rotationSpeed);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.forward * -rotationSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("joystick 1 button 0"))
            {
                rb.AddForce(gameObject.transform.up * speed);
                engMoving.Play();
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("joystick 1 button 1"))
            {
                rb.AddForce(gameObject.transform.up * -speed);
                //PlayOneShot(engIdle);
            }
        }
        if (gameObject.tag == "Player2")
        {
            Vector3 joyDirection = Vector3.zero;
            joyDirection.z = Input.GetAxis("Player2Steer");
            transform.Rotate(joyDirection * -rotationSpeed);

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.forward * -rotationSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey("joystick 2 button 0"))
            {
                rb.AddForce(gameObject.transform.up * speed);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey("joystick 2 button 1"))
            {
                rb.AddForce(gameObject.transform.up * -speed);
            }
        }
    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{

    //    // Respawning the player when OUT OF BOUNDS
    //    if (coll.gameObject.tag == "OB")
    //    {
    //        if (gameObject.tag == "Player1")
    //        {
    //            Instantiate(Player1, Spawn1.transform.position, Spawn1.transform.rotation);
    //            Destroy(gameObject);
    //        }

    //        if (gameObject.tag == "Player2")
    //        {
    //            Instantiate(Player2, Spawn2.transform.position, Spawn2.transform.rotation);
    //            Destroy(gameObject);
    //        }

    //        if (gameObject.tag == "Player3")
    //        {
    //            Instantiate(Player3, Spawn3.transform.position, Spawn3.transform.rotation);
    //            Destroy(gameObject);
    //        }

    //        if (gameObject.tag == "Player4")
    //        {
    //            Instantiate(Player4, Spawn4.transform.position, Spawn4.transform.rotation);
    //            Destroy(gameObject);
    //        }
    //    }

    //    // Adding force to simulate collisions of players
    //    if (coll.gameObject.tag == "Player2")
    //    {
    //        Vector2 direction = (coll.transform.position - transform.position).normalized;
    //        Player2.GetComponent<Rigidbody2D>().AddForce(direction * speed);
    //    }

    //}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "OB")
        {
            if (gameObject.tag == "Player1")
            {
                spawnScript.player1Exist = false;
                spawnScript.SpawnPlayer1();
                Destroy(gameObject);
            }

            if (gameObject.tag == "Player2")
            {
                spawnScript.player2Exist = false;
                spawnScript.SpawnPlayer2();
                Destroy(gameObject);
            }

            if (gameObject.tag == "Player3")
            {
                spawnScript.player3Exist = false;
                spawnScript.SpawnPlayer3();
                Destroy(gameObject);
            }

            if (gameObject.tag == "Player4")
            {
                spawnScript.player4Exist = false;
                spawnScript.SpawnPlayer4();
                Destroy(gameObject);
            }
        }
    }
}
