using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Spawn1;
    //public Rigidbody2D rbPlayer2;

    private Rigidbody2D rbplayer2;

    // object orginal position
    private Vector3 orginalPos;
    //object position
    private Vector3 pos;
    //object rotation
    private Vector3 rot;
    //object rotation 
    float angle;

    // Use this for initialization
    void Start()
    {
        
    }

    void Awake()
    {
        //rbPlayer2 = gameObject.GetComponent<Rigidbody2D>();
        pos = transform.position;
        rot = transform.rotation.eulerAngles;
        Spawn1 = GameObject.FindWithTag("Spawn1");
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        //converting the object euler angle's magnitude from to Radians    
        angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;

        
        if (gameObject.tag == "Player2")
        {
            //rotate object Right & Left with 'A' and 'D'
            if (Input.GetKey(KeyCode.D))
            {
                rot.z -= rotationSpeed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rot.z += rotationSpeed;
            }


            if (Input.GetKey(KeyCode.W))
            {
                pos.x += (Mathf.Cos(angle) * speed) * Time.deltaTime;
                pos.y += (Mathf.Sin(angle) * speed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                pos.x += (Mathf.Cos(angle) * -speed) * Time.deltaTime;
                pos.y += (Mathf.Sin(angle) * -speed) * Time.deltaTime;
            }
            //Apply
            transform.position = pos;
            transform.rotation = Quaternion.Euler(rot);
        }

     

    }

    
    void OnCollisionEnter2D(Collision2D coll) {

        // Respawning the player when OUT OF BOUNDS
        if (coll.gameObject.tag == "OB")
        {
            Instantiate(Player1, Spawn1.transform.position, Spawn1.transform.rotation);
            Destroy(gameObject);
            //Reset();
        }

        // Adding force to simulate collisions of players
        if (coll.gameObject.tag == "Player3")
        {
            Vector3 direction = (transform.position - coll.transform.position);
            Player3.GetComponent<Rigidbody2D>().AddForce(direction * speed);
        }
    }

    //void Reset() {
    //    this.gameObject.transform.position = Spawn1.transform.position;
    //}
}
