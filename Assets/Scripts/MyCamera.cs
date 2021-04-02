using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MyCamera : MonoBehaviour
{
    public List<Transform> GameTransforms;
    private int index = 0;
    private Vector3 pos;
    private bool firstRun = true;
    private GameObject[] planets;
    public Vector3 offset;
    void Start()
    {
        GameTransforms.Add(GameObject.Find("Spaceship").transform);
        GameTransforms.Add(GameObject.Find("Sun").transform);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Sun")
        {
            Material alphaMaterial = col.gameObject.GetComponent<Renderer>().material;

            alphaMaterial.color = new Color(alphaMaterial.color.r, alphaMaterial.color.g, alphaMaterial.color.b, 0.5f);

            col.gameObject.GetComponent<Renderer>().material = alphaMaterial;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Sun")
        {
            Material alphaMaterial = col.gameObject.GetComponent<Renderer>().material;

            alphaMaterial.color = new Color(alphaMaterial.color.r, alphaMaterial.color.g, alphaMaterial.color.b, 1.0f);

            col.gameObject.GetComponent<Renderer>().material = alphaMaterial;
        }
    }
    void LateUpdate()
    {
        if (firstRun)
        {
            firstRun = false;
            planets = GameObject.FindGameObjectsWithTag("Planet");
            foreach (GameObject planet in planets)
                GameTransforms.Add(planet.transform);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index--;
            if (index < 0)
                index = 0;
            if (GameTransforms[index].tag == "Sun")
                offset.z = -6f;
            else
                offset.z = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index++;
            if (index > GameTransforms.Count - 1)
                index = GameTransforms.Count - 1;
            if (GameTransforms[index].tag == "Sun")
                offset.z = -6f;
            else
                offset.z = -2f;
        }

        pos = GameTransforms[index].localPosition + offset;
        transform.localPosition = pos;
    }
}
