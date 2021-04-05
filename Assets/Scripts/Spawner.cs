using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject planetPrefab;
    public GameObject meteorPrefab;
    public List<GameObject> meteors = new List<GameObject>();
    public List<Planet> generatedPlanets = new List<Planet>();
    public List<Material> materialPlanets;
    [Range(1, 15)] public int planetCount = 8;
    private float distanceBetweenPlanet = 2.0f;
    private float time = 10;
    void Start()
    {
        for (int i = 0; i < planetCount; i++)
        {
            float distanceToCenter = 5 + (i + 1) * distanceBetweenPlanet;

            GameObject newPlanet = Instantiate(planetPrefab, new Vector3(distanceToCenter, 0, 0), Quaternion.identity);
            Planet planet = newPlanet.GetComponent<Planet>();

            int validIndex = i % materialPlanets.Count;
            planet.GetComponent<Renderer>().material = materialPlanets[validIndex];

            planet.radius = distanceToCenter;
            generatedPlanets.Add(planet);
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > 10)
        {
            time = 0;
            for (int i = 0; i < 50; i++)
            {
                Vector3 meteorSpawnPos;
                meteorSpawnPos.x = Random.Range(-20, 20);
                meteorSpawnPos.z = Random.Range(-20, 20);
                meteorSpawnPos.y = Random.Range(-20, 20);
                GameObject newMeteor = Instantiate(meteors[Random.Range(0, meteors.Count)], meteorSpawnPos,
                    Quaternion.identity);
            }
        }
    }
}