using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    void Start()
    {
        Vector3 forceVector3;
        forceVector3.x = Random.Range(-1, 1);
        forceVector3.y = Random.Range(-1, 1);
        forceVector3.z = Random.Range(-1, 1);
        Vector3 torqueVector3;
        torqueVector3.x = Random.Range(-1, 1);
        torqueVector3.y = Random.Range(-1, 1);
        torqueVector3.z = Random.Range(-1, 1);
        ConstantForce force = this.gameObject.GetComponent<ConstantForce>();
        force.force = forceVector3;
        force.torque = torqueVector3;
    }
    void Update()
    {
        if (transform.position.y < -50 || transform.position.y > 50 || transform.position.x > 50 ||
            transform.position.x < -50 || transform.position.z > 50 || transform.position.z < -50) 
        {
            Destroy(gameObject);
        }
    }
}
