using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    private HoleLogic hole;
    private ParticleSystem particles;
    private Collider2D collider;
    private WaitForSecondsRealtime waitTimer = new WaitForSecondsRealtime(5);
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        hole = gameObject.GetComponentInParent<HoleLogic>();
        collider = GetComponent<Collider2D>();
        hole.holeCount++;
    }
    public void DeactivateHole()
    {
        collider.enabled = false;
        particles.Stop();
        hole.holeCount--;
        
        StartCoroutine(RestartHole());
    }
    private IEnumerator RestartHole()
    {
        yield return waitTimer;
        collider.enabled = true;
        particles.Play();
        hole.holeCount++;
    }
}
