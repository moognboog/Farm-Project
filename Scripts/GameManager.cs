using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject hayField;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI mowPercentText;
    public TextMeshProUGUI rakePercentText;
    public TextMeshProUGUI balePercentText;
    public TextMeshProUGUI stackPercentText;

    public Button sellHayButton;
    public Button irrigateButton;
    public Button fertilizeButton;
    public Button nextSeasonButton;
    public Button startButton;

    public int money = 0;
    public int sellPrice = 20;
    public int irrigationPrice = 250;
    private int irrigationCounter = 0;
    private int irrigationLimit = 3;

    public int fertilizingPrice = 1000;
    private int fertilizerCounter = 0;
    private int fertilizerLimit = 1;

    public float hayGrown;
    public float hayMown;
    public float mowPercent;

    public float hayCutIn;
    public float hayCutOut;
    public float rakePercent;


    public float hayRakedIn;
    public float hayRakedOut;
    public float balePercent;


    public float hayBaledIn;
    public float hayBaledOut;
    public float stackPercent;


    public float hayStackedIn;
    public float hayStackedOut;
    

    

    // Start is called before the first frame update
    void Start()
    {
        hayField = GameObject.Find("HayField");
    }

    // Update is called once per frame
    void Update()
    {
        mowPercent = Mathf.Round((hayMown / hayGrown) * 100);
        rakePercent = Mathf.Round((hayCutOut / hayCutIn) * 100);
        balePercent = Mathf.Round((hayRakedOut / hayRakedIn) * 100);
        stackPercent = Mathf.Round((hayBaledOut / hayBaledIn) * 100);

        moneyText.text = "Money: $" + money;
        mowPercentText.text = "% Mowed: " + mowPercent + "%";
        
        if(rakePercent > 0)
        {
            rakePercentText.text = "% Raked: " + rakePercent + "%";
        }
        if(balePercent > 0)
        {
            balePercentText.text = "% Baled: " + balePercent + "%";
        }
        if(stackPercent > 0)
        {
            stackPercentText.text = "% Stacked: " + stackPercent + "%";
        }      
        

        if(mowPercent > 94)
        {
            mowPercentText.gameObject.SetActive(false);
            rakePercentText.gameObject.SetActive(true);
        }
        if(rakePercent > 95)
        {
            rakePercentText.gameObject.SetActive(false);
            balePercentText.gameObject.SetActive(true);
        }
        if(balePercent > 95)
        {
            balePercentText.gameObject.SetActive(false);
            stackPercentText.gameObject.SetActive(true);
        }
        if(stackPercent > 95)
        {
            stackPercentText.gameObject.SetActive(false);
            sellHayButton.gameObject.SetActive(true);
            irrigateButton.gameObject.SetActive(true);
            fertilizeButton.gameObject.SetActive(true);
            nextSeasonButton.gameObject.SetActive(true);
            

        }
    }

    public void HaySold()
    {
        money += sellPrice;
    }

    public void BuyIrrigation()
    {
        if(irrigationCounter < irrigationLimit && money > irrigationPrice)
        {
            money -= irrigationPrice;
            irrigationCounter++;
            hayField.GetComponent<GrowingHay>().Irrigate();
        }
        
    }

    public void BuyFertilizer()
    {
        if(fertilizerCounter < fertilizerLimit && money > fertilizingPrice)
        {
            money -= fertilizingPrice;
            fertilizerCounter++;
            hayField.GetComponent<GrowingHay>().Fertilize();
        }
    }

    public void NextSeason()
    {
        hayGrown = 0;
        hayMown = 0;
        hayCutIn = 0;
        hayCutOut = 0;
        hayRakedIn = 0;
        hayRakedOut = 0;
        hayBaledIn = 0;
        hayBaledOut = 0;
        hayStackedIn = 0;
        hayStackedOut = 0;
        mowPercent = .1f;
        rakePercent = .1f;
        balePercent = .1f;
        stackPercent = .1f;

        mowPercentText.gameObject.SetActive(true);
        sellHayButton.gameObject.SetActive(false);
        irrigateButton.gameObject.SetActive(false);
        fertilizeButton.gameObject.SetActive(false);
        nextSeasonButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);

        fertilizerCounter = 0;
        irrigationCounter = 0;
        hayField.GetComponent<GrowingHay>().grow = true;
        hayField.GetComponent<GrowingHay>().StartGrowingHay();

    }

    public void AddUnit(int unitType)
    {
        switch (unitType)
        {
            case 0:
                hayGrown++;
                Debug.Log("Added to case " + unitType);
                break;

            case 1:
                hayCutIn++;
                Debug.Log("Added to case " + unitType);
                break;

            case 2:
                hayRakedIn++;
                Debug.Log("Added to case " + unitType);
                break;

            case 3:
                hayBaledIn++;
                Debug.Log("Added to case " + unitType);
                break;

            case 4:
                hayStackedIn++;
                Debug.Log("Added to case " + unitType);
                break;

            case 5:
                hayMown++;
                Debug.Log("Suctracted from case " + unitType);
                break;

            case 6:
                hayCutOut++;
                Debug.Log("Suctracted from case " + unitType);
                break;

            case 7:
                hayRakedOut++;
                Debug.Log("Suctracted from case " + unitType);
                break;

            case 8:
                hayBaledOut++;
                Debug.Log("Suctracted from case " + unitType);
                break;

            case 9:
                hayStackedOut++;
                Debug.Log("Suctracted from case " + unitType);
                break;
        }   
        
    }
}
