﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        if (transform.position.y < -50)
        {
          Destroy(gameObject);
        }
    }
}