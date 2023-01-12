using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        CollectableControl.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
