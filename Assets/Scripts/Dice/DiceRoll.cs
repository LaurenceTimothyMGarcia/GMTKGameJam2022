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

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("Dice/");
    }

    void Update()
    {
        //Roll dice here still figuring out when to roll it
        if (Input.GetKeyDown(KeyCode.Mouse0))//change this to whatever we make it roll
        {
            StartCoroutine("RollDie");
        }
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
        Debug.Log(diceResult);
    }
}
