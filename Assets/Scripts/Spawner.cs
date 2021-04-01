using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject planetPrefab;
    private List<Planet> generatedPlanets = new List<Planet>();
    public List<Material> materialPlanets;

    [Range(1, 15)] public int planetCount = 8;
    private float distanceBetweenPlanet = 2.0f;
    void Start()
    {
        for (int i = 0; i < planetCount; i++)
        {
            float distanceToCenter = 5 + i * distanceBetweenPlanet;

            GameObject newPlanet = Instantiate(planetPrefab, new Vector3(distanceToCenter, 0, 0), Quaternion.identity);
            Planet planet = newPlanet.GetComponent<Planet>();
            
            int validIndex = i % materialPlanets.Count;
            planet.GetComponent<Renderer>().material = materialPlanets[validIndex];

            planet.radius = distanceToCenter;
            generatedPlanets.Add(planet);
        }
    }
}