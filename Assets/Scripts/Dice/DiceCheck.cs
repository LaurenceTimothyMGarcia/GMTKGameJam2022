using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheck : MonoBehaviour
{
    Health life;
    [SerializeField] GameObject player;

    WeaponActive currentWeapons;
    [SerializeField] GameObject cWeapon;

    [HideInInspector] public AudioManager diceSound;
    [SerializeField] GameObject dSound;

    //Dice 1
    [HideInInspector] public DiceRoll dRoll1;
    [SerializeField] GameObject dice1;
    [SerializeField] int rotateDie1;

    //Dice 2
    [HideInInspector] public DiceRoll dRoll2;
    [SerializeField] GameObject dice2;
    [SerializeField] int rotateDie2;

    //Dice 3
    [HideInInspector] public DiceRoll dRoll3;
    [SerializeField] GameObject dice3;
    [SerializeField] int rotateDie3;

    private int[] rollResultList = new int[3];
    public static int weaponRoll;

    void Awake()
    {
        life = player.GetComponent<Health>();

        currentWeapons = cWeapon.GetComponent<WeaponActive>();

        dRoll1 = dice1.GetComponent<DiceRoll>();
        dRoll1.rotateDie = rotateDie1;

        dRoll2 = dice2.GetComponent<DiceRoll>();
        dRoll2.rotateDie = rotateDie2;

        dRoll3 = dice3.GetComponent<DiceRoll>();
        dRoll3.rotateDie = rotateDie3;

        diceSound = dSound.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dRoll1.hasRolled)
        {
            rollResultList[0] = dRoll1.GetDiceResult();
        }

        if (dRoll2.hasRolled)
        {
            rollResultList[1] = dRoll2.GetDiceResult();
        }

        if (dRoll3.hasRolled)
        {
            rollResultList[2] = dRoll3.GetDiceResult();
            diceSound.StopPlaying("DiceRolling");
            diceSound.StopPlaying("DiceRolling2");
            diceSound.StopPlaying("DiceRolling3");
            diceSound.Play("DiceResult");
            dRoll1.hasRolled = false;
            dRoll2.hasRolled = false;
            dRoll3.hasRolled = false;

            weaponRoll = DiceListCheck(rollResultList);
            currentWeapons.WeaponSetActive(weaponRoll);
        }

        

        //currentWeapons.WeaponSetActive(weaponRoll);
    }

    private int DiceListCheck(int[] rollResultList)
    {
        //Default option is default gun
        int option = 0;

        life.invincibility = false;

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
