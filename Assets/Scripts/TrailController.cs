using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrailController : MonoBehaviour
{
    private TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            trail = GetComponentInParent<TrailRenderer>();
            trail.enabled = false;
        }
        else
        {
            trail = GetComponentInParent<TrailRenderer>();
            trail.enabled = true;
        }
    }
}
