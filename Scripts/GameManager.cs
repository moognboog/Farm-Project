using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI mowPercentText;
    public TextMeshProUGUI rakePercentText;
    public TextMeshProUGUI balePercentText;
    public TextMeshProUGUI stackPercentText;

    public Button sellHayButton;
    public Button irrigateButton;
    public Button fertilizeButton;

    public int money = 0;
    public int sellPrice = 20;

    public float hayGrown;
    public float hayMown;
    public float mowPercent = 0.1f;

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

    public GameObject tabMenu;
    private bool menuUp = false;

    public bool isWatered;
    public bool isFertilized;

    

    

    // Start is called before the first frame update
    void Start()
    {
        mowPercentText.gameObject.SetActive(true);  
    }

    // Update is called once per frame
    void Update()
    {
        mowPercent = Mathf.Round((hayMown / hayGrown) * 100);
        rakePercent = Mathf.Round((hayCutOut / hayCutIn) * 100);
        balePercent = Mathf.Round((hayRakedOut / hayRakedIn) * 100);
        stackPercent = Mathf.Round((hayBaledOut / hayBaledIn) * 100);

        moneyText.text = "Money: $" + money;
        if(mowPercent > 0)
        {
            mowPercentText.text = "Mowed: " + mowPercent + "%";
        }
        if(rakePercent > 0)
        {
            rakePercentText.text = "Raked: " + rakePercent + "%";
        }
        if(balePercent > 0)
        {
            balePercentText.text = "Baled: " + balePercent + "%";
        }
        if(stackPercent > 0)
        {
            stackPercentText.text = "Stacked: " + stackPercent + "%";
        }      
        

        if(mowPercent > 95)
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

        }
       
    }

    public void HaySold()
    {
        money += sellPrice;
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
                Debug.Log("Subtracted from case " + unitType);
                break;



        }
        
    }
    public void FirstSceneTransition()
    {
        SceneManager.LoadScene(1);
    }
    public void Irrigate()
    {
        isWatered = true;
    }
    public void Fertilize()
    {
        isFertilized = true;
    }
}
