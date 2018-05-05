using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    public GameObject Player1;
    public GameObject Spawn1;
    private Transform myTrans;

    // object orginal position
    Vector3 orginalPos;
    //object position
    Vector3 myPos;
    //object rotation
    Vector3 myRot;
    //object rotation 
    float angle;

    // Use this for initialization
    void Start()
    {
        myTrans = transform;
        myPos = myTrans.position;
        myRot = myTrans.rotation.eulerAngles;
    }

    void Awake()
    {
        Spawn1 = GameObject.FindWithTag("Spawn1");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //converting the object euler angle's magnitude from to Radians    
        angle = myTrans.eulerAngles.magnitude * Mathf.Deg2Rad;



        //rotate object Right & Left
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRot.z -= rotationSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRot.z += rotationSpeed;
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            myPos.x += (Mathf.Cos(angle) * speed) * Time.deltaTime;
            myPos.y += (Mathf.Sin(angle) * speed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            myPos.x += Mathf.Cos(angle) * Time.deltaTime;
            myPos.y += Mathf.Sin(angle) * Time.deltaTime;
        }

        //Apply
        myTrans.position = myPos;
        myTrans.rotation = Quaternion.Euler(myRot);

    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "OB")
        {
            Instantiate(Player1, Spawn1.transform.position, Spawn1.transform.rotation);
            Destroy(gameObject);
            //Reset();
        }
    }

    void Reset() {
        this.gameObject.transform.position = Spawn1.transform.position;
    }
}
