using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    float timeToDestroy;

    // Update is called once per frame

    private void Start()
    {
        timeToDestroy = Time.time + 35;
    }
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0.0f)
            Destroy(gameObject);
    }
    
}
