using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FarAttack : MonoBehaviour
{
    [SerializeField] CharacterType characterType;

    DragonBallPoolController dragonBallPoolController;
    GameObject target;

    GameObject[] allEnemy;

    private int dragonBallLine;
    private GameObject dragonBall;

    private float distanceToClosestTarget;
    private float distanceToTarget;
    public float _attackTime;


    private void Awake()
    {
        _attackTime = characterType.AttackTime;
        dragonBallPoolController = GameObject.FindObjectOfType<DragonBallPoolController>();
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
        dragonBall = dragonBallPoolController.dragonBallList[dragonBallLine].transform.gameObject;
        if (dragonBall.gameObject.activeInHierarchy)
        {
            dragonBallLine++;
            dragonBall = dragonBallPoolController.dragonBallList[dragonBallLine].transform.gameObject;

        }
        dragonBall.transform.position = transform.GetChild(0).transform.position;
        dragonBall.transform.gameObject.SetActive(true);
        dragonBallPoolController.dragonBallList[dragonBallLine].transform.DOMove(target.transform.position, 0.5f);
        dragonBallLine++;
    }

    void findNearEnemy()
    {
        distanceToClosestTarget = Mathf.Infinity;
        allEnemy = GameObject.FindGameObjectsWithTag(characterType.enemyTag);
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
