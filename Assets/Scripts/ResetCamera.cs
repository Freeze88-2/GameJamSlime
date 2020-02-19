using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    private Collider2D player;
    private bool entered;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            entered = true;
            player = other;

            Vector3 camPos = other.gameObject.transform.position;
            camPos.z = -10;

            Camera.main.transform.position = camPos;
        }
    }
    private void FixedUpdate()
    {
        if (entered)
        {
            Vector3 camPos = Vector3.zero;
            camPos.z = -10;

            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, camPos, 10 * Time.fixedDeltaTime);
        }
    }
}
