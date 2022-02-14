using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacker : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject[] stackedBale;
    private GameObject stackyard;
    public int baleCounter = 0;
    public int stackedHay= 0;

    public int inputType;
    public int outputType;

    // Start is called before the first frame update
    void Start()
    {
        stackyard = GameObject.Find("Stackyard Parent");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        stackedHay = GameObject.Find("Stackyard Parent").GetComponent<NewStackyard>().stackedHayCounter;             
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bale") && baleCounter < 18)
        {
            Destroy(other.gameObject);
            stackedBale[baleCounter].SetActive(true);
            gameManager.AddUnit(inputType);
            baleCounter++;    
        }        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Stackyard") && baleCounter > -1)
        {
            Debug.Log("Stackyard");
            stackedBale[baleCounter-1].SetActive(false);
            stackyard.GetComponent<NewStackyard>().StackDatHay();
            gameManager.AddUnit(outputType);
            baleCounter--;    
            
        }
    }
}
