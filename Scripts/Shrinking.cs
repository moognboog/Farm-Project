using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinking : MonoBehaviour
{
    private float scale = 1;
    public float shrinkRate = .1f;
    public float scaleLimit = .001f;
    public bool isEating = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEating)
        {
            Shrink();
        }
            
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        isEating = true;
    }

    private void Shrink()
    {
        Vector3 shrinkScale = new Vector3(.001f, .001f, .001f);
        float heightY = transform.position.y - .001f;

        if(scale > scaleLimit)
        {
            transform.localScale -= shrinkScale;
            transform.position = new Vector3(transform.position.x, heightY, transform.position.z);

            scale -= shrinkRate * Time.deltaTime;
        }           
        
    }
}
