using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoudaryController : MonoBehaviour {

    public Transform Spawn1;
    public GameObject Player1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player1")
        {
            Instantiate(Player1, Spawn1.position, Spawn1.rotation);
        }
    }
}
