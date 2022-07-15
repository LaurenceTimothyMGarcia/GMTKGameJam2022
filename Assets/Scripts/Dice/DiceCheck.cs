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

    private int[] rollResultList;

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
        
    }
}
