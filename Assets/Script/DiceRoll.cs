using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    private Sprite[] diceSides;
    public SpriteRenderer rend;
    public int whosTurn = 1;
    private bool isRolling = true;
    private void Start()
    {
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }
    private void OnMouseDown()
    {
        if (!GameControl.gameOver && isRolling)
            StartCoroutine("RollTheDice");
    }
    private IEnumerator RollTheDice()
    {
        isRolling = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        GameControl.diceSideThrown = randomDiceSide + 1;
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        }
        else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
        whosTurn *= -1;
        isRolling = true;
    }
}
