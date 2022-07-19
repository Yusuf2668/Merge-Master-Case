using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dinosaur"))
        {
            transform.gameObject.SetActive(false);
        }
    }
}
