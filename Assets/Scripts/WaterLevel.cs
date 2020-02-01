using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private GameObject waterContainer;
    private HoleLogic holeLogic;
    private Vector3 waterlevel;
    private Rigidbody2D rb;

    private void Start()
    {
        holeLogic = waterContainer.GetComponent<HoleLogic>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (rb.gravityScale > 0)
        {
            waterlevel.y = (holeLogic.HoleCount * 20);
            rb.velocity = waterlevel * Time.deltaTime;
        }
        else
        {
            rb.gravityScale = 8;
        }
    }
}
