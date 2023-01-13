using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision2 : MonoBehaviour {
    public GameObject parent;

    void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.FindWithTag("Player");

        player.GetComponent<PlayerMove>().enterCollision();
        parent.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
