using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorController : MonoBehaviour
{
    public float speed = 8;
    public float turnSpeed = 50;
    public float moveVertical;
    public float moveHorizontal;
    public float turning;
   

    public GameObject[] hayStates;
    private Vector3 tractorPosition;
    private Quaternion tractorQuat;
    public float hayOffsetZ = 1.0f;
    public GameObject mower;
    public GameObject rake;
    public GameObject baler;
    public GameObject stacker;
    public GameObject mowerInShed;
    public GameObject rakeInShed;
    public GameObject balerInShed;
    public GameObject stackerInShed;


    public bool mowerAttached = false;
    public bool rakeAttached = false;
    public bool balerAttached = false;
    public bool stackerAttached = false;
    public bool noImplement = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (MainManager.Instance.loaded)
        {
            transform.position = MainManager.Instance.savePos;
            transform.rotation = MainManager.Instance.saveRot;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        tractorQuat = transform.rotation;
        tractorPosition = transform.position;

        int reverse = 1;

        if (moveVertical < 0)
        {
            reverse = -1;
        }
        

        moveVertical = Input.GetAxis("Vertical");
        
        moveHorizontal = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveVertical);
        if(moveVertical> 0 || moveVertical < 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveHorizontal * reverse);
        }


        MainManager.Instance.savePos = transform.position;
        MainManager.Instance.saveRot = transform.rotation;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Mower Shop") && noImplement)
        {
            mower.SetActive(true);
            mowerInShed.SetActive(false);
            StartCoroutine(WaitToAttach(1));
            
        }
        else if(other.CompareTag("Rake Shop") && noImplement)
        {            
            rake.SetActive(true);
            rakeInShed.SetActive(false);
            StartCoroutine(WaitToAttach(2));
        }
        else if (other.CompareTag("Baler Shop") && noImplement)
        {            
            baler.SetActive(true);
            balerInShed.SetActive(false);
            StartCoroutine(WaitToAttach(3));
        }
        else if (other.CompareTag("Stacker Shop") && noImplement)
        {
            stacker.SetActive(true);
            stackerInShed.SetActive(false);
            StartCoroutine(WaitToAttach(4));
        }

        else if (other.CompareTag("Mower Shop") && mowerAttached)
        {
            mower.SetActive(false);
            mowerInShed.SetActive(true);
            StartCoroutine(WaitToDetach(1));
        }
        else if (other.CompareTag("Rake Shop") && rakeAttached)
        {
            rake.SetActive(false);
            rakeInShed.SetActive(true);
            StartCoroutine(WaitToDetach(2));
        }
        else if (other.CompareTag("Baler Shop") && balerAttached)
        {
            baler.SetActive(false);
            balerInShed.SetActive(true);
            StartCoroutine(WaitToDetach(3));
        }
        else if (other.CompareTag("Stacker Shop") && stackerAttached)
        {
            stacker.SetActive(false);
            stackerInShed.SetActive(true);
            StartCoroutine(WaitToDetach(4));
        }
    }

    IEnumerator WaitToAttach(int implement)
    {
        yield return new WaitForSeconds(2);
        noImplement = false;
        if(implement == 1)
        {
            mowerAttached = true;
        }
        else if (implement == 2)
        {
            rakeAttached = true;
        }
        else if (implement == 3)
        {
            balerAttached = true;
        }
        else if (implement == 4)
        {
            stackerAttached = true;
        }
    }

    IEnumerator WaitToDetach(int implement)
    {
        yield return new WaitForSeconds(2);
        noImplement = true;
        if (implement == 1)
        {
            mowerAttached = false;
        }
        else if (implement == 2)
        {
            rakeAttached = false;
        }
        else if (implement == 3)
        {
            balerAttached = false;
        }
        else if (implement == 4)
        {
            stackerAttached = false;
        }
    }

      
    


}
