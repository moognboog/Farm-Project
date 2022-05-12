using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    private float hayLimiter = .001f;
    private Quaternion rotation;
    public float maxSize = .2f;
    public bool isWatered = false;
    public bool isFertilized = false;
    public bool next = false;
    public bool cut = false;
    public int haySize = 0;

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
        haySize = 0;
        maxSize = 0.2f;
        isWatered = gameManager.isWatered;
        isFertilized = gameManager.isFertilized;
        next = gameManager.next;

        if (isWatered)
        {
            maxSize += .2f;
            haySize += 1;
            isWatered = false;
        }
        if (isFertilized)
        {
            maxSize += .2f;
            haySize += 2;
            isFertilized = false;
        }
        if (next)
        {
            gameObject.tag = "Hay";
            maxSize += .19f;
            cut = false;
        }
        if (cut)
        {
            maxSize -= .19f;
        }
        

        if (hayLimiter < maxSize)
        {
            IncreaseScale();
        }
    }
  



    private void IncreaseScale()
    {
        float scaleX = transform.localScale.x + .001f;
        float scaleY = transform.localScale.y + .003f;
        float scaleZ = transform.localScale.z + .001f;

        float heightY = transform.position.y + .0015f;

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
            cut = true;
            haySize = 0;
            
            hayLimiter = .001f;
            StartCoroutine(Untagger());
        }
    }
    IEnumerator Untagger()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.tag = "Untagged";
    }
   
}
