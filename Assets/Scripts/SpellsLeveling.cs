using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsLeveling : MonoBehaviour
{
    //allows us to call and edit variables from the GameManager.cs
    public GameManager GM;

    //intializing variables
    public float FireBallDPS = 1;
    public float FireballMod = 1;
    public float FireBallCostMod = 1.1f;
    public float IceShardDPS = 11;
    public float IceShardMod = 1;
    public float IceShardCostMod = 1.1f;
    public float PowerMissileDPS = 111;
    public float PowerMissileMod = 1;
    public float PowerMissileCostMod = 1.1f;

    //level fireball spell
    //every function here functions the exact same way
    public void FireballLevelUp ()
    {
        //do we have enough gold?
        if (GM.goldPieces >= GM.fireBallCost)
        {
            //calculate damage
            GM.damagePerSec += FireBallDPS * FireballMod;

            //spend our gold
            GM.goldPieces -= GM.fireBallCost;

            //update the cost for the next level
            GM.fireBallCost = GM.fireBallCost * FireBallCostMod;

            //increase the displayed level
            GM.fireBallLevel++;

            //print to screen
            GM.printing = true;
        }
    }

    public void IceShardLevelUp()
    {
        
        if(GM.goldPieces >= GM.iceShardCost)
        {
            GM.damagePerSec += IceShardDPS * IceShardMod;
            GM.goldPieces -= GM.iceShardCost;
            GM.iceShardCost = GM.iceShardCost * IceShardCostMod;
            GM.iceShardLevel++;

            GM.printing = true;
        }

    }

    public void PowerMissileLevelUp()
    {
        if (GM.goldPieces >= GM.powerMissileCost)
        {
            GM.damagePerSec += PowerMissileDPS * PowerMissileMod;
            GM.goldPieces -= GM.powerMissileCost;
            GM.powerMissileCost = GM.powerMissileCost * PowerMissileCostMod;
            GM.powerMissileLevel++;

            GM.printing = true;
        }

    }
}
