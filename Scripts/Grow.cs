using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    private float hayLimiter = .01f;



    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, .1f, transform.position.z);
        transform.localScale = new Vector3(.1f, .1f, .1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hayLimiter < .5)
        {
            IncreaseScale();
        }
    }

    
    private void IncreaseScale()
    {
        float scaleX = transform.localScale.x + .001f;
        float scaleY = transform.localScale.y + .002f;
        float scaleZ = transform.localScale.z + .001f;

        float heightY = transform.position.y + .001f;

        transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        transform.position = new Vector3(transform.position.x, heightY, transform.position.z);

        hayLimiter += .001f;

    }
}
