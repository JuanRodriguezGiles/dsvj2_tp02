using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ship : MonoBehaviour
{
    public float speed;
    void OnTriggerEnter(Collider col)
    {
        Material alphaMaterial = col.gameObject.GetComponent<Renderer>().material;

        alphaMaterial.color = new Color(alphaMaterial.color.r, alphaMaterial.color.g, alphaMaterial.color.b, 0.5f);

        col.gameObject.GetComponent<Renderer>().material = alphaMaterial;

        Debug.Log("pog");
    }
    void OnTriggerExit(Collider col)
    {
        Material alphaMaterial = col.gameObject.GetComponent<Renderer>().material;

        alphaMaterial.color = new Color(alphaMaterial.color.r, alphaMaterial.color.g, alphaMaterial.color.b, 1.0f);

        col.gameObject.GetComponent<Renderer>().material = alphaMaterial;

        Debug.Log("pog");
    }
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 directionVector3 = new Vector3(hor, 0, ver);

        transform.position += directionVector3 * speed * Time.deltaTime;
    }
}

