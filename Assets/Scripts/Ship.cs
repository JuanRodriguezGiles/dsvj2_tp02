using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ship : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 directionVector3 = new Vector3(hor, 0, ver);

        transform.position += directionVector3 * speed * Time.deltaTime;
    }
}

