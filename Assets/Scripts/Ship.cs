using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ship : MonoBehaviour
{
    public float speed;
    public float time = 0;
    //
    public float fowardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeFowardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float fowardAcceleration = 2.5f, hoverAcceleration = 2f;
    public float lookRateSpeed = 90f;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Planet" || col.gameObject.tag == "Sun")
        {
            Material alphaMaterial = col.gameObject.GetComponent<Renderer>().material;

            alphaMaterial.color = new Color(alphaMaterial.color.r, alphaMaterial.color.g, alphaMaterial.color.b, 0.5f);

            col.gameObject.GetComponent<Renderer>().material = alphaMaterial;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Planet" || col.gameObject.tag == "Sun")
        {
            Material alphaMaterial = col.gameObject.GetComponent<Renderer>().material;

            alphaMaterial.color = new Color(alphaMaterial.color.r, alphaMaterial.color.g, alphaMaterial.color.b, 1.0f);

            col.gameObject.GetComponent<Renderer>().material = alphaMaterial;
        }
    }
    void Update()
    {
        //float hor = Input.GetAxis("Horizontal");
        //float ver = Input.GetAxis("Vertical");

        //Vector3 directionVector3 = new Vector3(hor, 0, ver);
        //transform.position += directionVector3 * speed * Time.deltaTime;
        activeFowardSpeed = Mathf.Lerp(activeFowardSpeed, Input.GetAxisRaw("Vertical") * fowardSpeed,
            fowardAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed,
            hoverAcceleration * Time.deltaTime);

        transform.Rotate(0,
            Input.GetAxisRaw("Horizontal") * lookRateSpeed * Time.deltaTime, 0f, Space.Self);

        transform.position += transform.forward * activeFowardSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
    }
}