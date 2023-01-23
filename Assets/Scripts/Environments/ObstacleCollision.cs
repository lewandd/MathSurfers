using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.FindWithTag("Player");

        player.GetComponent<PlayerMove>().enterCollision();
        
        this.gameObject.SetActive(false);
    }
}
