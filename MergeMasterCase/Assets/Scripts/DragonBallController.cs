using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBallController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.gameObject.SetActive(false);
        }
    }
}
