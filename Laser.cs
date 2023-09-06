﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacle , player_layer;

    public GameObject death_effect;

    public float laser_multipler = 1;

    private bool laser_hit;

    public float range = 100f;


    private void Update()
    {

        //Line Renderer

        GetComponent<LineRenderer>().enabled = true;
        laser_hit = true;

        if (Physics.Raycast(transform.position , transform.forward , out hit , range , obstacle))
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1 , hit.point);
            GetComponent<LineRenderer>().startWidth = 0.025f * laser_multipler + Mathf.Sin(Time.time) / 80;

        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            laser_hit = false;
        }
        //Kill Player
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, player_layer))
        {
            if (laser_hit)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    hit.transform.gameObject.GetComponent<PlayerManager>().Death();
                }
            }
        }

    }
}
