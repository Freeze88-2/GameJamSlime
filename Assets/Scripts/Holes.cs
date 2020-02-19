using System.Collections;
using UnityEngine;

public class Holes : MonoBehaviour
{
    private HoleLogic hole;
    private ParticleSystem particles;
    private CircleCollider2D circleCollider;
    private WaitForSecondsRealtime waitTimer = null;
    private SpriteRenderer render;

    [SerializeField] private readonly Sprite stickySprite = null;
    [SerializeField] private readonly Sprite normalSprite = null;
    [SerializeField] private readonly float respawnTimer = 5;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        waitTimer = new WaitForSecondsRealtime(respawnTimer);
        particles = GetComponentInChildren<ParticleSystem>();
        hole = gameObject.GetComponentInParent<HoleLogic>();
        circleCollider = GetComponent<CircleCollider2D>();
        render.sprite = normalSprite;
        hole.HoleCount++;
    }
    private void Update()
    {
        if (hole.HoleCount <= 0)
        {
            StopAllCoroutines();
        }
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
