using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    private float hayLimiter = .01f;
    private Quaternion rotation;
    public float maxSize;
    public bool isWatered = false;
    public bool isFertilized = false;
    public bool next = false;

    private GameManager gameManager;

    

    
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        gameManager.AddUnit(0);

        rotation = Quaternion.Euler(0f, Random.Range(0.0f, 360f), .5f);
        transform.position = new Vector3(transform.position.x, .1f, transform.position.z);
        transform.localScale = new Vector3(.1f, .1f, .1f);
        transform.rotation = rotation;


    }

    // Update is called once per frame
    void Update()
    {
        isWatered = gameManager.isWatered;
        isFertilized = gameManager.isFertilized;
        next = gameManager.next;


        maxSize = .1f;

        if (isWatered)
        {
            maxSize += .4f;
        }
        if (isFertilized)
        {
            maxSize += .5f;
        }
        if (next)
        {
            gameObject.tag.Replace("Untagged", "Hay");
        }
        

        if (hayLimiter < maxSize)
        {
            IncreaseScale();
        }
    }

    
    private void IncreaseScale()
    {
        float scaleX = transform.localScale.x + .001f;
        float scaleY = transform.localScale.y + .001f;
        float scaleZ = transform.localScale.z + .001f;

        float heightY = transform.position.y + .001f;

        transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        transform.position = new Vector3(transform.position.x, heightY, transform.position.z);

        hayLimiter += .001f;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mower"))
        {
            rotation = Quaternion.Euler(0f, Random.Range(0.0f, 360f), .5f);
            transform.position = new Vector3(transform.position.x, .1f, transform.position.z);
            transform.localScale = new Vector3(.1f, .1f, .1f);
            transform.rotation = rotation;

            isWatered = false;
            isFertilized = false;
            gameObject.tag.Replace(tag, "Untagged");
        }
    }
   
}
