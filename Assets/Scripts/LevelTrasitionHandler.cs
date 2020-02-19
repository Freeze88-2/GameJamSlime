using UnityEngine;

public class LevelTrasitionHandler : MonoBehaviour
{
    [SerializeField] private GameObject endCheck;
    private EndCheck checker;

    private void Start()
    {
        checker = endCheck.GetComponent<EndCheck>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (checker.async?.progress == 0.9f)
            {
                DontDestroyOnLoad(other.gameObject);
                Vector3 pos = other.gameObject.transform.position;
                pos.y = 5;
                other.gameObject.transform.position = pos;
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
}
