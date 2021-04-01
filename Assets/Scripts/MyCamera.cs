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
    public float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset;
    void Start()
    {
        GameTransforms.Add(GameObject.Find("Ship").transform);
        GameTransforms.Add(GameObject.Find("Sun").transform);
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
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index++;
            if (index > GameTransforms.Count - 1)
                index = GameTransforms.Count - 1;
        }

        Vector3 desiredPosition = GameTransforms[index].localPosition + offset;
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, desiredPosition, ref velocity, smoothTime);
        transform.LookAt(GameTransforms[index]);
    }
}
