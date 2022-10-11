using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour{

    [SerializeField] private Transform pfBrokenWall;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Barbarian"))
        {
            Instantiate(pfBrokenWall, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }



}
