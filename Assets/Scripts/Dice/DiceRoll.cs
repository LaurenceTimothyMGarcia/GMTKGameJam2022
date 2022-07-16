using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    //How many iterations die should roll
    public int rotateDie;
    public int diceResult;

    //Array of dice sprites
    private Sprite[] diceSides;
    //Sprite renderer to change sprite
    private SpriteRenderer render;
    //Provides a call to DiceCheck if it has been rolled
    public bool hasRolled = false;

    //Timer Related functions
    private float currentTime;
    public int startTime;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("Dice/");
        currentTime = startTime;
    }

    void Update()
    {
        //Roll dice here still figuring out when to roll it
        currentTime = currentTime - Time.deltaTime;

        if (currentTime <= 0.001)//change this to whatever we make it roll
        {
            StartCoroutine("RollDie");
        }
    }

    public int GetDiceResult()
    {
        return diceResult;
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

        //render.size += new Vector2(0.5f, 0.5f);
        //Tells the dice check it can grab the new number
        hasRolled = true;

        //Resets Timer
        currentTime = startTime;
    }
}
