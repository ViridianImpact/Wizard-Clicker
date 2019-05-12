using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPop : MonoBehaviour
{
    //find our panels
    public GameObject SpellsPanel;
    public GameObject UpgradePanel;
    public GameObject AwardsPanel;
    public GameObject StatsPanel;
    public GameObject MenuPanel;

    //tells us if the panel has been opened already
    public int count;

    /*every function works the same as this one except the final two MenuOpen and Menu Close
        this is because only the menu panel covers the entire screen and therefor needs a separate button withing the menu panel to close itself */

    //toggle visualization of the spells panel
    public void SpellsToggle()
    {
        //is it open already?
        if (count == 1)
        {
            //turn the panel off
            SpellsPanel.gameObject.SetActive(false);

            //it's closed
            count = 0;
        }
        else
        {
            //turn on the spells panel and turn off evey other panel just in case NO OVERLAYING PANELS
            SpellsPanel.gameObject.SetActive(true);
            UpgradePanel.gameObject.SetActive(false);
            AwardsPanel.gameObject.SetActive(false);
            StatsPanel.gameObject.SetActive(false);
            MenuPanel.gameObject.SetActive(false);

            //it's open
            count = 1;
        }

        print("panels swapped");
    }

    public void UpgradeToggle()
    {
        if (count == 2)
        {
            UpgradePanel.gameObject.SetActive(false);

            count = 0;
        }
        else
        {
            SpellsPanel.gameObject.SetActive(false);
            UpgradePanel.gameObject.SetActive(true);
            AwardsPanel.gameObject.SetActive(false);
            StatsPanel.gameObject.SetActive(false);
            MenuPanel.gameObject.SetActive(false);

            count = 2;
        }

        print("panels swapped");
    }

    public void AwardsToggle()
    {
        if (count == 3)
        {
            AwardsPanel.gameObject.SetActive(false);

            count = 0;
        }
        else
        {
            SpellsPanel.gameObject.SetActive(false);
            UpgradePanel.gameObject.SetActive(false);
            AwardsPanel.gameObject.SetActive(true);
            StatsPanel.gameObject.SetActive(false);
            MenuPanel.gameObject.SetActive(false);

            count = 3;
        }

        print("panels swapped");
    }

    public void StatsToggle()
    {
        if (count == 4)
        {
            StatsPanel.gameObject.SetActive(false);

            count = 0;
        }
        else
        {
            SpellsPanel.gameObject.SetActive(false);
            UpgradePanel.gameObject.SetActive(false);
            AwardsPanel.gameObject.SetActive(false);
            StatsPanel.gameObject.SetActive(true);
            MenuPanel.gameObject.SetActive(false);

            count = 4;
        }

        print("panels swapped");
    }

    //open menu panel
    public void MenuOpen()
    {
        //activate menu panel and deactivate all other panels
        SpellsPanel.gameObject.SetActive(false);
        UpgradePanel.gameObject.SetActive(false);
        AwardsPanel.gameObject.SetActive(false);
        StatsPanel.gameObject.SetActive(false);
        MenuPanel.gameObject.SetActive(true);

        print("panels swapped");
    }

    //close menu panel
    public void MenuClose()
    {
        //deactivate menu panel
        MenuPanel.gameObject.SetActive(false);

        print("panel closed");
    }
}
