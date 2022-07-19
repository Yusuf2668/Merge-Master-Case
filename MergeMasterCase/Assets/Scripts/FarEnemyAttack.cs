using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FarEnemyAttack : MonoBehaviour
{
    [SerializeField] CharacterType characterType;

    EnemyBallRepositoryController enemyBallRepositoryController;
    GameObject target;

    GameObject[] allEnemy;

    private int enemyBallLine;
    private GameObject enemyBall;

    private float distanceToClosestTarget;
    private float distanceToTarget;
    private float _attackTime;


    private void Awake()
    {
        _attackTime = characterType.AttackTime;
        enemyBallRepositoryController = GameObject.FindObjectOfType<EnemyBallRepositoryController>();
    }
    private void Update()
    {
        if (characterType.startGame)
        {
            _attackTime -= Time.deltaTime;
            switch (_attackTime)
            {
                case <= 0:
                    findNearEnemy();
                    Attack();
                    _attackTime = characterType.AttackTime;
                    break;
            }
        }
    }
    void Attack()
    {
        enemyBall = enemyBallRepositoryController.enemyBallList[enemyBallLine].transform.gameObject;
        if (enemyBall.gameObject.activeInHierarchy)
        {
            enemyBallLine++;
            enemyBall = enemyBallRepositoryController.enemyBallList[enemyBallLine].transform.gameObject;
        }
        enemyBall.transform.position = transform.GetChild(1).transform.position;
        enemyBall.transform.gameObject.SetActive(true);
        enemyBallRepositoryController.enemyBallList[enemyBallLine].transform.DOMove(target.transform.position, 0.5f);
        enemyBallLine++;
        if (enemyBallRepositoryController.enemyBallList.Count == enemyBallLine)
        {
            enemyBallLine = 0;
        }
    }

    void findNearEnemy()
    {
        distanceToClosestTarget = Mathf.Infinity;
        allEnemy = GameObject.FindGameObjectsWithTag(characterType.characterTag);
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
}
