using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 2)] private float orbitSpeed;
    [SerializeField] [Range(0.1f, 1)] private float rotationSpeed;
    [SerializeField] [Range(1, 100)] public float radius;
    [SerializeField] private bool sun;
    private float angle = 0;

    void Start()
    {
        orbitSpeed=Random.Range(0.5f, 1.5f);
        rotationSpeed = Random.Range(0.1f, 1.0f);
    }
    void Update()
    {
        if (sun)
            return;

        Vector3 v3 = Vector3.zero;
        angle += orbitSpeed * Time.deltaTime;

        v3.x = radius * Mathf.Cos(angle);
        v3.z = radius * Mathf.Sin(angle);

        transform.localPosition = v3;
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
}