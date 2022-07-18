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
    private bool attackTheEnemy;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        attackTime = 0;
        walk = true;
        attackTheEnemy = false;
        animator.SetTrigger("Walk");
    }


    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, 1f, characterType.enemyLayerMask))
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
            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, characterType.walkSpeed * Time.deltaTime);
        }
    }



    void findNearEnemy()
    {
        distanceToClosestTarget = Mathf.Infinity;
        allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemy.Length == 0)
        {
            characterType.startGame = false;
            attackTheEnemy = false;
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

    }

    void AttackTheEnemy()
    {
        switch (attackTime)
        {
            case <= 0:
                target.GetComponent<EnemyController>().TakeDamage(characterController.characterLevel * 10f);
                attackTime = characterType.AttackTime;
                animator.SetTrigger("Attack");
                break;
        }

    }
    void AttackTheCharacter()
    {
        switch (attackTime)
        {
            case <= 0:
                target.GetComponent<CharacterController>().TakeDamage(characterController.characterLevel * 10f);
                attackTime = characterType.AttackTime;
                animator.SetTrigger("Attack");
                break;
        }
    }
}
