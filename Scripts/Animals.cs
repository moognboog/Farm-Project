using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    public float turnSpeed = 3f;
    public float speed = 3.0f;
    private GameObject bale;
    private Rigidbody cowRB;
    public bool isBale = false;
    public Quaternion lookQuat;
    public Vector3 lookDirection;
    void Start()
    {
        cowRB = GetComponent<Rigidbody>();
    }

   
    void FixedUpdate()
    {
        if (isBale)
        {
            FindBale();
        }
    }



    private void FindBale()
    {
        bale = GameObject.Find("Bale");
              
        lookDirection = (bale.transform.position - transform.position).normalized;

        float singleStep = turnSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, lookDirection, singleStep, 0.0f);

        cowRB.AddForce(lookDirection * speed);

        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void BalePlaced()
    {
        isBale = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isBale = false;
    }

}
