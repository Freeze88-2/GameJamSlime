using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrasitionHandler : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject endCheck;
    private EndCheck checker;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        checker = endCheck.GetComponent<EndCheck>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (checker.async.progress == 0.9f)
        {
            Vector3 pos = player.transform.position;
            pos.y = 5;
            player.transform.position = pos;
            checker.async.allowSceneActivation = true;
        }
        else
        {
            Vector3 pos = other.transform.position;
            pos.y += 10;
            other.transform.position = pos;
        }
    }
}
