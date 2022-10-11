using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Spell"))
        {
            Debug.Log("hello");
            Destroy(GameObject.FindWithTag("Door"));
            Destroy(GetComponent<OpenDoor>());
        }
    }
}
