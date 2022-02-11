using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayDrying : MonoBehaviour
{
    public GameObject dryHay;
    public bool dry = false;
    public float dryTime =15;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DryingHay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DryingHay()
    {
        yield return new WaitForSeconds(dryTime);
        dry = true;
        Instantiate(dryHay, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
