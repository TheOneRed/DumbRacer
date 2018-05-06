﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public bool player1Exist = false;
    public bool player2Exist = false;
    public bool player3Exist = false;
    public bool player4Exist = false;


    private void Start()
    {
        SpawnPlayer1();
        SpawnPlayer2();
        SpawnPlayer3();
        SpawnPlayer4();
    }

    public void SpawnPlayer1()
    {
        if(!player1Exist)
        {
            Instantiate(player1, spawn1.transform.position, spawn1.transform.rotation);
            player1Exist = true;
        }
        else
        {
            return;
        }
        
    }
    public void SpawnPlayer2()
    {
        if (!player2Exist)
        {
            Instantiate(player2, spawn2.transform.position, spawn2.transform.rotation);
            player2Exist = true;
        }
        else
        {
            return;
        }
    }
    public void SpawnPlayer3()
    {
        if (!player3Exist)
        {
            Instantiate(player3, spawn3.transform.position, spawn3.transform.rotation);
            player3Exist = true;
        }
        else
        {
            return;
        }
    }
    public void SpawnPlayer4()
    {
        if (!player4Exist)
        {
            Instantiate(player4, spawn4.transform.position, spawn4.transform.rotation);
            player4Exist = true;
        }
        else
        {
            return;
        }
    }
}