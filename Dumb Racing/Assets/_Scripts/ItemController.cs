using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    public static string p1Item;
    public static string p2Item;
    public PlayerController playerController;
    public GameObject bumper;
    public Transform bumperSpawn;
    public GameObject pikePrefab;
    public Transform pikeSpawn;
    public GameObject push;
    public Transform pushSpawn;

    GameObject bumperObj;
    GameObject pikeObj;
    



    // Update is called once per frame
    void Update () {
        if(this.tag == "Player1")
        {

            switch (p1Item)
            {
                case "Speed Boost":
                    if (Input.GetKeyDown("space"))
                    {
                        StartCoroutine(SpeedTime());
                        playerController.speed = 35;
                        p1Item = null;
                    }
                    break;

                case "Bumper":
                    if (Input.GetKeyDown("space"))
                    {
                        Destroy(bumperObj);
                        bumperObj = Instantiate(bumper, bumperSpawn.position, bumperSpawn.rotation);
                        p1Item = null;
                        
                    }
                    break;

                case "Size":
                    if (Input.GetKeyDown("space"))
                    {
                        StartCoroutine(SizeTime());
                        if (BombManager.playerWithBomb == 1)
                        {
                            transform.localScale = new Vector3(5f, 5f, 1f);
                        } else
                        {
                            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                        }
                        p1Item = null;
                    }
                    break;

                case "Push":
                    if (Input.GetKeyDown("space"))
                    {
                        Instantiate(push, pushSpawn.position, pushSpawn.rotation);
                        p1Item = null;
                    }
                    break;

                case "Pike":
                    if (Input.GetKeyDown("space"))
                    {
                        pikeObj = Instantiate(pikePrefab, pikeSpawn.position, pikeSpawn.rotation);
                        pikeObj.GetComponent<PikePosition>().pikeSpawnTransform = pikeSpawn;
                        p1Item = null;
                    }
                    break;
            }
        }
		
	}


    IEnumerator SpeedTime()
    {

        yield return new WaitForSeconds(5);
        playerController.speed = 15;
        yield break;

    }

    IEnumerator SizeTime()
    {

        yield return new WaitForSeconds(5);
        transform.localScale = new Vector3(1f, 1f, 1f);
        yield break;

    }


}
