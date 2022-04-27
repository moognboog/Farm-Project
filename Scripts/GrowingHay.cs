using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingHay : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject hay;
    private Vector3 randomHayLocation;
    private Quaternion randomHayRotation;

    public float randomX;
    public float randomY;
    public float randomZ;
    public float yOffset;
    public float fieldSizeX;
    public float fieldSizeZ;
    
    private float hayBoundX;
    private float hayBoundZ;

    private float spawnRate;

    private int calcGrowthRate = 1;

    public int growTime = 15;

    public bool grow = true;

    public float watering;
    public float fertilizing;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("GrowHay", 1f, .5f);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        Invoke("GrowHay", .1f);
        StartCoroutine(GrowTime());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   

    IEnumerator GrowTime()
    {
       
        yield return new WaitForSeconds(growTime);
        grow = false;
        

    }

    private void GrowHay()
    {
        gameManager.AddUnit(0);
        spawnRate = (watering + fertilizing) / Random.Range(3f,5f);

        hayBoundX = transform.position.x + fieldSizeX;
        hayBoundZ = transform.position.z + fieldSizeZ;

        randomX = Random.Range(transform.position.x, hayBoundX);
        randomY = Random.Range(0, 180);
        randomZ = Random.Range(transform.position.z, hayBoundZ);

        randomHayLocation = new Vector3(randomX, yOffset, randomZ);
        randomHayRotation = Quaternion.Euler(0, randomY, 0);

        if (grow) 
        {
            Instantiate(hay, randomHayLocation, randomHayRotation);
            Invoke("GrowHay", spawnRate);
        }


        
    }
}
