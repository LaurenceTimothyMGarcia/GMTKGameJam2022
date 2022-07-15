using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheck : MonoBehaviour
{
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

        Debug.Log("Dice 1: " + rollResultList[0]);
        Debug.Log("Dice 2: " + rollResultList[1]);
        Debug.Log("Dice 3: " + rollResultList[2]);

        
    }
}
