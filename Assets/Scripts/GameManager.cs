using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //Assigning my notations
    readonly string[] shortNotation = new string[12] { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc" };


    //Assigning Canvases
    public GameObject SpellsPanel;
    public GameObject UpgradesPanel;

    //Displays on main panel
    public Text GoldDisp;
    public Text DPPSDisp;
    public Text SpellbooksDisp;
    public Text StageDisp;
    public Text StageTimerDisp;
    public Text EnemyTimerDisp;
    public Text stageName;

    //displays on spell panel
    //Level
    public Text FireBallLevelDisp;
    public Text IceShardLevelDisp;
    public Text PowerMissileLevelDisp;
    public Text ShatterLevelDisp;
    public Text ForcePrisonLevelDisp;
    public Text HolyLightLevelDisp;
    public Text SunBurstLevelDisp;
    public Text MindDaggerLevelDisp;
    public Text FingerofDeathLevelDisp;
    //Cost
    public Text CostDisp;
    public Text FireBallCostDisp;
    public Text IceShardCostDisp;
    public Text PowerMissileCostDisp;
    public Text ShatterCostDisp;
    public Text ForcePrisonCostDisp;
    public Text HolyLightCostDisp;
    public Text SunBurstCostDisp;
    public Text MindDaggerCostDisp;
    public Text FingerofDeathCostDisp;

    //Main Game Variables
    public float goldPieces = 0;
    public float damagePerSec = 0;
    public float damagePerClick = 1;
    public float spellbooks = 0;
    public float stageTimer = 0;
    public float enemyTimer = 0;
    public float rand = 0;
    public float goldMod = 1;
    public float enemyThreat = 5;

    //Spell Variables
    public int fireBallLevel = 0;
    public int iceShardLevel = 0;
    public int powerMissileLevel = 0;
    public int shatterLevel = 0;
    public int forcePrisonLevel = 0;
    public int holyLightLevel = 0;
    public int sunBurstLevel = 0;
    public int mindDaggerLevel = 0;
    public int fingerofDeathLevel = 0;

    public float fireBallCost = 5;
    public float iceShardCost = 50;
    public float powerMissileCost = 500;
    public float shatterCost = 5000;
    public float forcePrisonCost = 50000;
    public float holyLightCost = 500000;
    public float sunBurstCost = 5000000;
    public float mindDaggerCost = 50000000;
    public float fingerofDeathCost = 500000000;

    //Game Background Statistics
    public int clicks = 0;
    public int stage = 1;
    public float enemyHP = 5;
    public bool check = false;
    public int cost = 1;
    public bool printing = true;

    //time keeping for current enemy stage and total
    public int seconds = 0;
    public int secondsStage = 0;
    public int secondsSum = 0;
    public int minutes = 0;
    public int minutesStage = 0;
    public int minutesSum = 0;
    public int hours = 0;
    public int hoursStage = 0;
    public int hoursSum = 0;
    public int days = 0;
    public int daysStage = 0;
    public int daysSum = 0;
    public int years = 0;
    public int yearsStage = 0;
    public int yearsSum = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Time());
        StartCoroutine(DamagePerSec());
        SpellsPanel.gameObject.SetActive(false);
        UpgradesPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //turning printing on whenever there is a change to be printed otherwise printing once a second
        while (printing == true)
        {
            GoldDisp.text = "Gold Pieces: " + BigNumberReduction(shortNotation, goldPieces, "N0");
            DPPSDisp.text = "Damage / Sec: " + BigNumberReduction(shortNotation, damagePerSec, "N0");
            SpellbooksDisp.text = "SpellBooks: " + BigNumberReduction(shortNotation, spellbooks, "N0");
            StageDisp.text = "Stage: " + BigNumberReduction(shortNotation, stage, "N0");
            FireBallLevelDisp.text = "Lvl: " + fireBallLevel;
            CostDisp.text = "X " + BigNumberReduction(shortNotation, cost, "N0");

            PopulateSpellsDisp(cost);

            StageTimerDisp.text = hoursStage.ToString("00") + ":" + minutesStage.ToString("00") + ":" + secondsStage.ToString("00");
            EnemyTimerDisp.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");

            printing = false;
        }

        //checking for a boss encounter every 10 levels
        if (stage % 10 == 0 && check == false)
        {
            enemyHP = (int)(enemyThreat * 5);
            check = true;
        }

        //checking for dead enemy
        if (enemyHP <= 0)
        {
            enemyThreat = DropGold(enemyThreat);
        }
    }

    //time
    private void TimeAdd()
    {
        seconds += 1;
        secondsStage += 1;
        secondsSum += 1;

        printing = true;

        if (seconds >= 60)
        {
            minutes += 1;
            minutesStage += 1;
            minutesSum += 1;
            seconds = 0;
            secondsStage = 0;
            secondsSum = 0;

            if (minutes >= 60)
            {
                hours += 1;
                hoursStage += 1;
                hoursSum += 1;
                minutes = 0;
                minutesStage = 0;
                minutesSum = 0;

                if (hours >= 24)
                {
                    days += 1;
                    daysStage += 1;
                    daysSum += 1;
                    hours = 0;
                    hoursStage = 0;
                    hoursSum = 0;

                    if (days >= 365)
                    {
                        years += 1;
                        yearsStage += 1;
                        yearsSum += 1;
                        days = 0;
                        daysStage = 0;
                        daysSum = 0;
                    }
                }
            }
        }
    }

    //calculate how much gold is dropped when dead
    private float DropGold(float enemyThreat)
    {
        rand = Random.Range(1, 1.4f);

        if (stage % 10 == 0)
        {
            goldPieces += (int)(enemyThreat * rand * goldMod) * 10;
            secondsStage = 0;
            minutesStage = 0;
            hoursStage = 0;
            daysStage = 0;
            yearsStage = 0;
        }
        else
        {
            goldPieces += (int)(enemyThreat * rand * goldMod);
        }
        enemyThreat = enemyThreat * 1.2f;
        enemyHP = (int)enemyThreat;
        seconds = 0;
        minutes = 0;
        hours = 0;
        days = 0;
        years = 0;
        stage++;
        check = false;
        printing = true;

        return enemyThreat;
    }

    //updates the text on screen for the spells display panel
    private void PopulateSpellsDisp(int cost)
    {
        FireBallLevelDisp.text = "Lvl: " + fireBallLevel;
        FireBallCostDisp.text = BigNumberReduction(shortNotation, fireBallCost, "N0") + " GP";
        IceShardLevelDisp.text = "Lvl: " + iceShardLevel;
        IceShardCostDisp.text = BigNumberReduction(shortNotation, iceShardCost, "N0") + " GP";
        PowerMissileLevelDisp.text = "Lvl: " + powerMissileLevel;
        PowerMissileCostDisp.text = BigNumberReduction(shortNotation, powerMissileCost, "N0") + " GP";
        ShatterLevelDisp.text = "Lvl: " + shatterLevel;
        ShatterCostDisp.text = BigNumberReduction(shortNotation, shatterCost, "N0") + " GP";
        ForcePrisonLevelDisp.text = "Lvl: " + forcePrisonLevel;
        ForcePrisonCostDisp.text = BigNumberReduction(shortNotation, forcePrisonCost, "N0") + " GP";
        HolyLightLevelDisp.text = "Lvl: " + holyLightLevel;
        HolyLightCostDisp.text = BigNumberReduction(shortNotation, holyLightCost, "N0") + " GP";
        SunBurstLevelDisp.text = "Lvl: " + sunBurstLevel;
        SunBurstCostDisp.text = BigNumberReduction(shortNotation, sunBurstCost, "N0") + " GP";
        MindDaggerLevelDisp.text = "Lvl: " + mindDaggerLevel;
        MindDaggerCostDisp.text = BigNumberReduction(shortNotation, mindDaggerCost, "N0") + " GP";
        FingerofDeathLevelDisp.text = "Lvl: " + fingerofDeathLevel;
        FingerofDeathCostDisp.text = BigNumberReduction(shortNotation, fingerofDeathCost, "N0") + " GP";
    }

    //runs our time in the background
    IEnumerator Time()
    {
        while (true)
        {
            TimeAdd();
            yield return new WaitForSeconds(1);
        }
    }

    //runs the damage per second in the background
    IEnumerator DamagePerSec()
    {
        while (true)
        {
            enemyHP -= damagePerSec * .1f;
            yield return new WaitForSeconds(.1f);
        }
    }

    //once we get to 10000 it reduces the print size to make things cleaner
    public string BigNumberReduction(string[] notations, float bignumber, string lowDecimalFormat)
    {
        float value = bignumber;
        int baseValue = 0;
        string notationValue = "";
        string toStringValue;

        //checks for the correct size number
        if (value >= 10000)
        {
            value /= 1000;
            baseValue++;

            //checks how many 1000's
            while (Mathf.Round((float)value) >= 1000)
            {
                value /= 1000;
                baseValue++;
            }

            //assigns string format for number
            if (baseValue < 2)
            {
                toStringValue = "N1";
            }
            else
            {
                toStringValue = "N2";
            }

            //assigns notaion
            if (baseValue > notations.Length)
            {
                return null;
            }
            else
            {
                notationValue = notations[baseValue];
            }
        }
        else
        {
            toStringValue = lowDecimalFormat;
        }

        printing = true;

        // eg. "4321 GP", "54.32 K GP", "78.65 M GP"
        return value.ToString(toStringValue) + " " + notationValue;
    }
}
