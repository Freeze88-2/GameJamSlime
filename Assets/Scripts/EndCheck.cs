using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCheck : MonoBehaviour
{
    public AsyncOperation async;
    private Collider2D player;
    private bool entered;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            entered = true;
            player = other;
            Scene scene = SceneManager.GetActiveScene();

            async = SceneManager.LoadSceneAsync(scene.buildIndex + 1, LoadSceneMode.Single);
            async.allowSceneActivation = false;
        }
    }
    private void FixedUpdate()
    {
        if (entered)
        {
            Vector3 camPos = player.gameObject.transform.position;
            camPos.z = -10;

            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, camPos, -player.attachedRigidbody.velocity.y * 2 * Time.fixedDeltaTime);
        }
    }
}
