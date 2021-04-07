using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ship : MonoBehaviour
{
    public float speed;
    public float resultAngle;
    public float resultRealAngle;
    public float fowardSpeed = 25f, hoverSpeed = 5f;
    private float activeFowardSpeed, activeHoverSpeed;
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

        //Vector3 movement = new Vector3(hor, 0, ver) * speed;
        //transform.position += movement * Time.deltaTime;

        //Vector3 lastPosition = transform.position;

        //Vector3 wantedPosition = transform.position + movement * Time.deltaTime;

        //float anguloReal = RealAngle(lastPosition, wantedPosition);
        //resultRealAngle = anguloReal;

        //Quaternion currentRotation = transform.rotation;
        //Quaternion newRotation = Quaternion.Euler(0, anguloReal, 0);
        //Quaternion finalRotation = Quaternion.Slerp(currentRotation, newRotation, 1 * Time.deltaTime);

        //if (Mathf.Abs(hor) > 0.001f || Mathf.Abs(ver) > 0.001f)
        //    transform.rotation = finalRotation;

        activeFowardSpeed = Mathf.Lerp(activeFowardSpeed, Input.GetAxisRaw("Vertical") * fowardSpeed,
            fowardAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed,
            hoverAcceleration * Time.deltaTime);

        transform.Rotate(0,
            Input.GetAxisRaw("Horizontal") * lookRateSpeed * Time.deltaTime, 0f, Space.Self);

        transform.position += transform.forward * activeFowardSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
    }

    float RealAngle(Vector3 from, Vector3 to)
    {
        Vector3 right = Vector3.right;
        Vector3 vectorDirection = to - from;

        float angle = Vector3.Angle(right, vectorDirection);

        resultAngle = angle;

        Vector3 cross = Vector3.Cross(right, vectorDirection);

        if (cross.y < 0)
        {
            angle = 360 - angle;
        }

        return angle;
    }
}