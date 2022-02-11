using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStackyard : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject[] bales;
    private GameObject baleToSet;
    public int baleNumber = 0;

    public GameObject stacker;
    public int stackedHayCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellDatHay()
    {
        if (baleNumber > 0)
        {
            baleNumber--;
            Debug.Log("Stacked Hay is " + stackedHayCounter);
            bales[baleNumber].SetActive(false);
            gameManager.AddUnit(9);
            gameManager.HaySold();
            
            stackedHayCounter--;
        }

    }

    public void StackDatHay()
    {
        if(baleNumber < bales.Length)
        {
            bales[baleNumber].SetActive(true);
            baleNumber++;
        }
        
    }



}
