using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Implements : MonoBehaviour
{
    private GameManager gameManager;
    public float hayOffsetZ = 1.0f;
    public float hayOffsetY = 1f;
    public float hayOffsetX = 1f;
    public GameObject newObject;
    private Vector3 implementPosition;
    private Quaternion implementQuat;
    public string inputObjectTag;
    public int hayInputCap;

    private int hayCount = 1;

    public int intakeType;
    public int outputType;




    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        implementPosition = transform.position;
        implementQuat = transform.rotation;

        
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag(inputObjectTag))
        {
            Destroy(other.gameObject);
            gameManager.AddUnit(intakeType);
            hayCount++;
            

        }
        if (hayCount > hayInputCap)
        {
            Vector3 offset = new Vector3(hayOffsetX, hayOffsetY, hayOffsetZ);
            Instantiate(newObject, implementPosition + offset, implementQuat);
            gameManager.AddUnit(outputType);
            hayCount = 1;


        }
    }
}

