﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
    {
        //if player fall to lava

        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerManager>().Death();
        }
    }
}
