using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    private Light pointLight;
    private float time;
    private float value;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        value = 0;
        pointLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        value = Mathf.Sin(time);
        pointLight.intensity = 5 + (value * 2);
    }
}
