using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{


    public int playerScore;
    public Text PlayerScore;

    public void Update()
    {
        PlayerScore.text = "Player Score: " + playerScore;   
    }
}