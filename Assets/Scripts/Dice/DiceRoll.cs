using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    //How many iterations die should roll
    public int rotateDie;
    public int diceResult;

    public GameObject dice;

    //Array of dice sprites
    private Sprite[] diceSides;
    //Sprite renderer to change sprite
    private SpriteRenderer render;
    //Provides a call to DiceCheck if it has been rolled
    public bool hasRolled = false;

    //Timer Related functions
    public float interval = 10f;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("Dice/");
        //currentTime = startTime;

        InvokeRepeating("StartRoll", 0f, interval);
    }

    void Update()
    {
        //Roll dice here still figuring out when to roll it
        //currentTime = currentTime - Time.deltaTime;

        /*if (Input.GetKey(KeyCode.W))//change this to whatever we make it roll
        {
            StartCoroutine("RollDie");
        }*/
    }

    public int GetDiceResult()
    {
        return diceResult;
    }

    private void StartRoll()
    {
        DiceCheck dSound = dice.GetComponent<DiceCheck>();
        dSound.diceRollTitle.text = "Rolling...";
        dSound.diceSound.Play("DiceRolling");
        dSound.diceSound.Play("DiceRolling2");
        dSound.diceSound.Play("DiceRolling3");
        StartCoroutine(RollDie());
    }

    private IEnumerator RollDie()
    {
        int randomDiceSide = 0;
        int finalResultSide = 0;

        //How many times to switch between dice
        for (int i = 0; i <= rotateDie; i++)
        {
            randomDiceSide = Random.Range(0,5);

            render.sprite = diceSides[randomDiceSide];

            yield return new WaitForSeconds(0.05f);
        }

        finalResultSide = randomDiceSide + 1;
        diceResult = finalResultSide;
        
        //Tells the dice check it can grab the new number
        hasRolled = true;

        //Resets Timer
        //currentTime = startTime;
    }
}
