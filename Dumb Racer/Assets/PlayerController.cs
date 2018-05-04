using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    //transform
    Transform myTrans;
    //object position
    Vector3 myPos;
    //object rotation
    Vector3 myRot;
    //object rotation 
    float angle;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myTrans = transform;
        myPos = myTrans.position;
        myRot = myTrans.rotation.eulerAngles;
    }

    void Update()
    {
        //transform.Translate(Vector2.forward * Time.deltaTime);
        //transform.Translate(Vector2.up * Time.deltaTime);
        //rb.velocity.y = speed;
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


        //move object Forward & Backward

            myPos.x += (Mathf.Cos(angle) * speed) * Time.deltaTime;
            myPos.y += (Mathf.Sin(angle) * speed) * Time.deltaTime;
        


        //Apply
        myTrans.position = myPos;
        myTrans.rotation = Quaternion.Euler(myRot);

    }
}
