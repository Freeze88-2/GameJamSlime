using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private GameObject waterContainer;
    [SerializeField] private int waterSpeed = 10;

    private HoleLogic holeLogic;
    private Vector3 waterlevel;
    private Rigidbody2D rb;

    private void Start()
    {
        holeLogic = waterContainer.GetComponent<HoleLogic>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (holeLogic.HoleCount > 0)
        {
            waterlevel.y = (holeLogic.HoleCount * waterSpeed);
            rb.velocity = waterlevel * Time.fixedDeltaTime;
        }
        else
        {
            rb.gravityScale = 8;
        }
    }
}
