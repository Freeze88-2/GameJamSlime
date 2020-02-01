using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private GameObject waterContainer;
    private HoleLogic holeLogic;

    private void Start()
    {
        holeLogic = waterContainer.GetComponent<HoleLogic>();
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.001f * holeLogic.holeCount, transform.position.z);
    }
}
