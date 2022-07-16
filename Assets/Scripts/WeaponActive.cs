using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActive : MonoBehaviour
{
    public GameObject[] weaponArray = new GameObject[12];

    DiceCheck chooseWeapon;
    public GameObject diceTriplet;

    // Start is called before the first frame update
    void Start()
    {
        //Sets everything to false
        Debug.Log("Inital Startup");
        //WeaponSetActive(0);
        weaponArray[0].SetActive(true);
        // weaponArray[6].SetActive(false);
        chooseWeapon = diceTriplet.GetComponent<DiceCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if dice 1 2 and 3 are not currently rolling then runs the set active
        // if (!chooseWeapon.dRoll1.hasRolled && !chooseWeapon.dRoll2.hasRolled && !chooseWeapon.dRoll3.hasRolled)
        // {
        //     //Debug.Log("WEapon Roll: " + DiceCheck.weaponRoll);
        //      WeaponSetActive(DiceCheck.weaponRoll);
        //     //Debug.Log("Is weapon active? " + weaponArray[DiceCheck.weaponRoll].activeSelf);
        // }
    }

    //Sets everything to false except the current weapon
    public void WeaponSetActive(int currentWeapon)
    {
        for (int i = 0; i < weaponArray.Length; i++)
        {
            weaponArray[i].SetActive(i == currentWeapon);
        }
    }
}
