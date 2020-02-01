using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    private HoleLogic hole;
    private ParticleSystem particles;
    private CircleCollider2D circleCollider;
    private WaitForSecondsRealtime waitTimer = null;
    private SpriteRenderer render; 

    [SerializeField] private Sprite stickySprite = null;
    [SerializeField] private Sprite normalSprite = null;
    [SerializeField] private float respawnTimer = 5;
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        waitTimer = new WaitForSecondsRealtime(respawnTimer);
        particles = GetComponentInChildren<ParticleSystem>();
        hole = gameObject.GetComponentInParent<HoleLogic>();
        circleCollider = GetComponent<CircleCollider2D>();
        hole.HoleCount++;
    }
    public void DeactivateHole()
    {
        particles.Stop();
        hole.HoleCount--;
        circleCollider.enabled = false;
        render.sprite = stickySprite;
        StartCoroutine(RestartHole());
    }
    private IEnumerator RestartHole()
    {
        yield return waitTimer;
        particles.Play();
        hole.HoleCount++;
        circleCollider.enabled = true;
        render.sprite = normalSprite;
    }
}
