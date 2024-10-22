using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NearAttack : MonoBehaviour
{
    [SerializeField] CharacterType characterType;

    CharacterController characterController;

    private GameObject target;

    private Animator animator;

    private float attackTime;
    private float distanceToClosestTarget;
    private float distanceToTarget;
    GameObject[] allEnemy;

    private bool walk;

    bool attack;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        attackTime = 0;
        walk = true;
        animator.SetTrigger("Walk");
    }


    private void Update()
    {
        if (attack)
        {
            AttackTheEnemy();
            attackTime -= Time.deltaTime;
            walk = false;
        }
        else
        {
            walk = true;
        }
        if (characterType.startGame && walk)
        {
            findNearEnemy();
            transform.Translate(transform.forward * Time.deltaTime * characterType.walkSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Enemy"))
        {
            attack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Enemy"))
        {
            attack = false;
        }
    }
    void findNearEnemy()
    {
        distanceToClosestTarget = Mathf.Infinity;
        allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemy.Length == 0)
        {
            characterType.startGame = false;
        }
        for (int i = 0; i < allEnemy.Length; i++)
        {
            distanceToTarget = (allEnemy[i].transform.position - gameObject.transform.position).sqrMagnitude;
            if (distanceToTarget < distanceToClosestTarget)
            {
                distanceToClosestTarget = distanceToTarget;
                target = allEnemy[i];
            }
        }
        transform.LookAt(target.transform);
    }

    void AttackTheEnemy()
    {
        if (!target.activeInHierarchy)
        {
            attack = false;
            return;
        }
        switch (attackTime)
        {
            case <= 0:
                target.GetComponent<EnemyController>().TakeDamage(characterController.characterLevel * 10f);
                attackTime = characterType.AttackTime;
                animator.SetTrigger("Attack");
                break;
        }

    }

}
