using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisonLogic : MonoBehaviour
{
    bool interact;
    // Update is called once per frame
    void Update()
    {
        interact = Input.GetKey(KeyCode.E);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
            Debug.Log("dieded");
        if (collision.CompareTag("Hole"))
        {
            Debug.Log("here");
            if (interact)
            {
                Debug.Log("jomn");
                collision.gameObject.GetComponent<Holes>().DeactivateHole();
            }
        }
    }
}
