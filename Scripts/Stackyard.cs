using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stackyard : MonoBehaviour
{
    public GameObject bale;
    public int baleCapacity = 36;
    public int baleCount = 0;
    public float balePosX;
    public float balePosY;
    public float balePosZ;

    public int baleCounterX = 0;
    public int baleCounterY = 0;
    public int baleCounterZ = 0;

    public int baleLimitX = 9;
    public int baleLimitY = 10;
    public int baleLimitZ = 5;

    public float baleOffsetX = 1.1f;
    public float baleOffsetY = 1.1f;
    public float baleOffsetZ = 2.1f;


    public bool nextRow = false;

    private Vector3 originalBalePosition;
    private bool startedStack = false;

    // Start is called before the first frame update
    void Start()
    {
        originalBalePosition = transform.position;
        balePosX = transform.position.x;
        balePosY = transform.position.y;
        balePosZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(baleCount < 1)
        {
            startedStack = false;
        }
    }

    private void OnMouseDown()
    {
        if (!startedStack)
        {
            Instantiate(bale, originalBalePosition, transform.rotation);
            baleCount++;
            startedStack = true;
            baleCounterX++;
            baleCounterY++;
            baleCounterZ++;
            
        }
        else if (startedStack)
        {
            Instantiate(bale, BalePosition(), transform.rotation);
            baleCount++;
        }
           

    }

    Vector3 BalePosition()
    {
         return new Vector3(BalePositionX(), BalePostionY(), BalePositionZ()) ;
    }

    float BalePositionX()
    {
        if(baleCounterX < baleLimitX)
        {
            balePosX = balePosX + baleOffsetX;
            nextRow = false;
            baleCounterX++;
        }
        else if(baleCounterX == baleLimitX)
        {
            balePosX = originalBalePosition.x;
            nextRow = true;
            baleCounterX = 1;
        }
        return balePosX;
    }
    float BalePositionZ()
    {
        if(baleCounterZ < baleLimitZ && nextRow)
        {
            balePosZ = balePosZ + baleOffsetZ;
            baleCounterZ++;
            
        }
        else if (baleCounterZ == baleLimitZ && nextRow)
        {
            balePosZ = originalBalePosition.z;
            nextRow = true;
            baleCounterZ = 1;
        }
        return balePosZ;
    }

    float BalePostionY()
    {
        if (baleCounterY < baleLimitY && baleCounterZ == baleLimitZ && nextRow)
        {
            balePosY = balePosY + baleOffsetY;
            baleCounterY++;
        }
        return balePosY;
    }

   
}
