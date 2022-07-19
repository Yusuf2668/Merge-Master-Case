using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float _health;

    public int enemyLevel;

    [SerializeField] CharacterType characterType;

    Slider healthBar;

    private void Start()
    {
        _health = characterType.characterHealth * enemyLevel;
        healthBar = transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<Slider>();
        healthBar.maxValue = _health;
        healthBar.value = _health;
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
        healthBar.value = _health;
    }
}
