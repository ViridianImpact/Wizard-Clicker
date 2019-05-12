using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCost : MonoBehaviour
{
    //allows us to call and edit variables from GameManager.cs
    public GameManager GM;

    //change the quantity of items purchased at once
    public void CostChange()
    {
        //checks what cost is already set to and rotates to the next stage going {1, 10, 100}
        if (GM.cost == 1)
        {
            GM.cost = 10;
        }
        else if (GM.cost == 10)
        {
            GM.cost = 100;
        }
        else if (GM.cost == 100)
        {
            GM.cost = 1;
        }

        //print to screen
        GM.printing = true;
    }
}
