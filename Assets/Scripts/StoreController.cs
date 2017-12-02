using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour {

    public int storeID;
    private int currentDiscount = 0;
    // Setters
    public void setDiscount(int newDiscount)
    {
        switch (newDiscount)
        {
            case 0:
                currentDiscount = 30;
                break;
            case 1:
                currentDiscount = 50;
                break;
            case 2:
                currentDiscount = 70;
                break;
            default:
                currentDiscount = 0;
                break;
        }
    }

    // Getters
    public int getDiscount()
    {
        return currentDiscount;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
