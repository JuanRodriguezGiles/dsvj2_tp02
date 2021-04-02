using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Vector3 scale = new Vector3(-0.5f, -0.5f, -0.5f);
        if (col.gameObject.tag == "Planet" || col.gameObject.tag == "Sun")
        {
            col.transform.localScale += scale;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (transform.position.y < -50)
        {
          Destroy(gameObject);
        }
    }
}
