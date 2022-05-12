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
    public Button nextSeasonButton;

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
    
    public bool isWatered;
    public bool isFertilized;
    private int irrPrice = 250;
    private int ferPrice = 5000;

    public bool next = false;
    public bool seasonIrr = false;
    public bool seasonFer = false;
    
    

    

    // Start is called before the first frame update
    void Start()
    {
        mowPercentText.gameObject.SetActive(true);  
    }

    // Update is called once per frame
  
    void Update()
    {
        
        if(money >= irrPrice)
        {
            irrigateButton.interactable = true;
        }
        else
        {
            irrigateButton.interactable = false;
        }

        if(money >= ferPrice)
        {
            fertilizeButton.interactable = true;
        }
        else
        {
            fertilizeButton.interactable = false;
        }

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
        if(rakePercent > 99)
        {
            rakePercentText.gameObject.SetActive(false);
            balePercentText.gameObject.SetActive(true);
        }
        if(balePercent > 99)
        {
            balePercentText.gameObject.SetActive(false);
            stackPercentText.gameObject.SetActive(true);
        }
        if(stackPercent > 99)
        {
            stackPercentText.gameObject.SetActive(false);
            sellHayButton.gameObject.SetActive(true);
            irrigateButton.gameObject.SetActive(true);
            fertilizeButton.gameObject.SetActive(true);
            next = true;
            isWatered = false;
            isFertilized = false;
            seasonFer = false;
            seasonIrr = false;
            ResetPercentages();
            StartCoroutine(NextOff());
            
        }
       
    }
    IEnumerator NextOff()
    {
        yield return new WaitForSeconds(5);
        next = false;
    }

    public void HaySold()
    {
        money += sellPrice;
    }

    
    public void Irrigate()
    {
        if(money >= irrPrice && !seasonIrr)
        {
            isWatered = true;
            money -= irrPrice;
            StartCoroutine(GrowTimeIrr());
            seasonIrr = true;
            irrigateButton.gameObject.SetActive(false);
        }        
    }
    public void Fertilize()
    {
        if(money >= ferPrice && !seasonFer)
        {
            isFertilized = true;
            money -= ferPrice;
            StartCoroutine(GrowTimeFer());
            seasonFer = true;
            fertilizeButton.gameObject.SetActive(false);
        }
        
    }
    IEnumerator GrowTimeIrr()
    {
        yield return new WaitForSeconds(7);
        isWatered = false;
    }
    IEnumerator GrowTimeFer()
    {
        yield return new WaitForSeconds(7);
        isFertilized = false;
        
    }
  private void ResetPercentages()
    {
        
        hayMown = 0f;
        hayCutIn = 0.1f;
        hayCutOut = 0f;
        hayRakedIn = 0.1f;
        hayRakedOut = 0f;
        hayBaledIn = 0.1f;
        hayBaledOut = 0f;
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
                Debug.Log("Subtracted from case " + unitType);
                break;

            case 6:
                hayCutOut++;
                Debug.Log("Subtracted from case " + unitType);
                break;

            case 7:
                hayRakedOut++;
                Debug.Log("Subtracted from case " + unitType);
                break;

            case 8:
                hayBaledOut++;
                Debug.Log("Subtracted from case " + unitType);
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
}
