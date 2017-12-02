using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const int numActiveDiscounts = 3; // km per sec.
    public const float timeOut = 15; // in seconds
}

public class StoreManager: MonoBehaviour {

  

    GameObject[] storeArray;
    int[] storesWithDiscount = new int[Constants.numActiveDiscounts];   // 0 - discount = 30%
                                                                        // 1 - discount = 50%
                                                                        // 2 - discount = 70%

    float[] storesDiscountTimeOut = new float[Constants.numActiveDiscounts];
    int storesNumber;

    // Use this for initialization
    void Start() {
        storeArray = GameObject.FindGameObjectsWithTag("Store");
        storesNumber = storeArray.Length;
        for (int i=0; i < Constants.numActiveDiscounts; ++i)
        {
            // 1 second = 50 calls
            storesDiscountTimeOut[i] = Constants.timeOut + Random.Range(-2, 2);
        }
    }

	// Update is called once per frame
	void Update () {

        assignDiscount();
        Debug.Log(storesDiscountTimeOut[0]);

	}

    void FixeUpdate()  // called very 20ms
    {
  
    }
    private void assignDiscount()
    {
        for (int i = 0; i < Constants.numActiveDiscounts; ++i)
        {
            if (storesDiscountTimeOut[i] <= 0.0)
            {
                int newDiscountedStore = Random.Range(0, storesNumber);
                storesWithDiscount[i] = newDiscountedStore;
                Debug.Log("TimeOut in store " + i + ". NewDiscount in store " + newDiscountedStore);
                storeArray[newDiscountedStore].GetComponent<StoreController>().setDiscount(i);
                storesDiscountTimeOut[i] = Constants.timeOut + Random.Range(-2, 2);
            }

            storesDiscountTimeOut[i]-= Time.deltaTime;
        }
    }
}
