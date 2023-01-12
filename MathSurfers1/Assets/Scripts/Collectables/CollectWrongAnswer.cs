using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWrongAnswer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //PlayerMove.removeLife();
        PlayerMove.lives--;
        this.gameObject.SetActive(false);
    }
}
