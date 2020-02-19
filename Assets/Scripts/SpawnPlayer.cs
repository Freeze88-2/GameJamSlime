using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            GameObject spawn = GameObject.FindGameObjectWithTag("Respawn");
            Instantiate(player, spawn.transform.position, Quaternion.identity);
        } 
    }
}
