using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject ingameDisplay;
    public GameObject ingamelivesCountDisplay;
    public GameObject endgameDisplay;
    public GameObject endgameScoreDisplay;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        ingameDisplay.GetComponent<Canvas>().enabled = true;
        endgameDisplay.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        ingamelivesCountDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + PlayerMove.lives;
        endgameScoreDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + CollectableControl.coinCount;
    }

    public void setGameOver()
    {
        ingameDisplay.GetComponent<Canvas>().enabled = false;
        endgameDisplay.GetComponent<Canvas>().enabled = true;
    }
}
