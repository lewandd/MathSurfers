using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGoodAnswer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        CollectableControl.coinCount += 10;
        this.gameObject.SetActive(false);
    }
}
