using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheck : MonoBehaviour
{
    WeaponActive currentWeapons;

    //Dice 1
    DiceRoll dRoll1;
    [SerializeField] GameObject dice1;
    [SerializeField] int rotateDie1;

    //Dice 2
    DiceRoll dRoll2;
    [SerializeField] GameObject dice2;
    [SerializeField] int rotateDie2;

    //Dice 3
    DiceRoll dRoll3;
    [SerializeField] GameObject dice3;
    [SerializeField] int rotateDie3;

    private int[] rollResultList = new int[3];
    public static int weaponRoll;

    void Awake()
    {
        dRoll1 = dice1.GetComponent<DiceRoll>();
        dRoll1.rotateDie = rotateDie1;

        dRoll2 = dice2.GetComponent<DiceRoll>();
        dRoll2.rotateDie = rotateDie2;

        dRoll3 = dice3.GetComponent<DiceRoll>();
        dRoll3.rotateDie = rotateDie3;
    }

    // Update is called once per frame
    void Update()
    {
        if (dRoll1.hasRolled)
        {
            rollResultList[0] = dRoll1.GetDiceResult();
            dRoll1.hasRolled = false;
        }

        if (dRoll2.hasRolled)
        {
            rollResultList[1] = dRoll2.GetDiceResult();
            dRoll1.hasRolled = false;
        }

        if (dRoll3.hasRolled)
        {
            rollResultList[2] = dRoll3.GetDiceResult();
            dRoll1.hasRolled = false;
        }

        //Debug to check list of dice
        //Debug.Log("Dice 1: " + rollResultList[0]);
        //Debug.Log("Dice 2: " + rollResultList[1]);
        //Debug.Log("Dice 3: " + rollResultList[2]);

        weaponRoll = DiceListCheck();

        //currentWeapons.WeaponSetActive(weaponRoll);

        /*switch(weaponRoll)
        {
            //Default - pistol HERE
            case 0:
                
                break;
            
            //111 - Worst Roll, melee
            case 1:
                break;
            
            //314 - Turn into pie
            case 2:
                break;
            
            //421 - weed
            case 3:
                break;
            
            //666 - Enemies just dead, reroll
            case 4:
                break;
            
            //555 - Mario Star invinciblity
            case 5:
                break;

            //All numbers are the same - machine gun HERE
            case 6:
                break;

            //1st and 3rd die are the same - sniper HERE
            case 7:
                break;
            
            //1st and 2nd die are the same - Whip
            case 8:
                break;
            
            //2nd and 3rd die are the same - grenade launcher HERE
            case 9:
                break;
            
            //Increasing Numbers - Force Push + Could use to help player jump more
            case 10:
                break;
            
            //Decreasing Numbers - laser gun/eyes HERE
            case 11:
                break;
        }*/
    }

    int DiceListCheck()
    {
        //Default option is default gun
        int option = 0;

        //Rolls 111 shittiest roll, gives just melee
        if (rollResultList[0] == 1 && rollResultList[1] == 1 && rollResultList[2] == 1)
        {
            option = 1;
            return option;
        }

        //Rolls 314 - Turn into pie
        if (rollResultList[0] == 3 && rollResultList[1] == 1 && rollResultList[2] == 4)
        {
            option = 2;
            return option;
        }

        //Rolls 420 - Something about weed
        if (rollResultList[0] == 4 && rollResultList[1] == 2 && rollResultList[2] == 1)
        {
            option = 3;
            return option;
        }

        //Rolls 666 - Enemies just dead, reroll
        if (rollResultList[0] == 6 && rollResultList[1] == 6 && rollResultList[2] == 6)
        {
            option = 4;
            return option;
        }

        //Rolls 555 - Mario star invincible
        if (rollResultList[0] == 5 && rollResultList[1] == 5 && rollResultList[2] == 5)
        {
            option = 5;
            return option;
        }

        //Rolls all same number - Machine Gun
        if (rollResultList[0] == rollResultList[1] && rollResultList[1] == rollResultList[2])
        {
            option = 6;
            return option;
        }

        //Rolls first and third die the same - Sniper
        if (rollResultList[0] == rollResultList[2])
        {
            option = 7;
            return option;
        }

        //Rolls first and second are same - Whip
        if (rollResultList[0] == rollResultList[1])
        {
            option = 8;
            return option;
        }

        //Rolls second and third die the same - Bomb thrower?
        if (rollResultList[1] == rollResultList[2])
        {
            option = 9;
            return option;
        }

        //Rolls consectutively increasing numbers - Force Push
        if ((rollResultList[0] + 2) == (rollResultList[1] + 1) && (rollResultList[1] + 1) == rollResultList[2])
        {
            option = 10;
            return option;
        }

        //Rolls consectutively decreasing numbers - Laser gun/eyes?
        if ((rollResultList[2] + 2) == (rollResultList[1] + 1) && (rollResultList[1] + 1) == rollResultList[0])
        {
            option = 11;
            return option;
        }

        //Other options if possible//
        /*
            dice 1 + dice 2 = dice 3
            dice 1 - dice 2 = dice 3
            all evens
            all odds
        */

        return option;
    }
}
