using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject planetPrefab;
    public List<Planet> generatedPlanets = new List<Planet>();

    [Range(1, 15)] public int planetCount = 8;
    private float distanceBetweenPlanet = 2.0f;
    void Start()
    {
        for (int i = 0; i < planetCount; i++)
        {
            float distanceToCenter = 1 + i * distanceBetweenPlanet;

            GameObject newPlanet = Instantiate(planetPrefab, new Vector3(distanceToCenter, 0, 0), Quaternion.identity);
            Planet planet = newPlanet.GetComponent<Planet>();

            planet.radius = distanceToCenter;
            generatedPlanets.Add(planet);
        }
    }
}