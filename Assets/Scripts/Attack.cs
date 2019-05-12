using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //alllows us to call and edit variables from GameManager.cs
    public GameManager GM;

    //attack the enemy on button click
    public void AttackClick()
    {
        //reduce enemy Hit Points
        GM.enemyHP -= GM.damagePerClick;

        //increase num of clicks
        GM.clicks += 1;

        //print to screen
        GM.printing = true;
    }
}
