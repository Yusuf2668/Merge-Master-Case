using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float _health;

    private void Start()
    {
        _health = 100;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            transform.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DragonBall"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(float damageValue)
    {
        _health -= damageValue;
    }
}
