using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActive : MonoBehaviour
{
    public GameObject[] weaponArray = new GameObject[12];

    // Start is called before the first frame update
    void Start()
    {
        //Sets everything to false
        WeaponSetActive(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sets everything to false except the current weapon
    public void WeaponSetActive(int currentWeapon)
    {
        for (int i = 0; i < weaponArray.Length; i++)
        {
            if (currentWeapon == -1)
            {
                weaponArray[i].SetActive(false);
                continue;
            }

            if (i == currentWeapon)
            {
                weaponArray[i].SetActive(true);
            }
            else
            {
                weaponArray[i].SetActive(false);
            }
        }
    }
}
