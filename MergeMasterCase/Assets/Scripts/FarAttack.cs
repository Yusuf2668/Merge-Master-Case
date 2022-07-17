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

    int dragonBallLine;
    GameObject dragonBall;

    float distanceToClosestTarget;
    float distanceToTarget;

    private void Awake()
    {
        dragonBallPoolController = GameObject.FindObjectOfType<DragonBallPoolController>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            findNearEnemy();
            Attack();
        }
    }
    void Attack()
    {
        dragonBall = dragonBallPoolController.dragonBallList[dragonBallLine].transform.gameObject;
        dragonBall.transform.position = transform.GetChild(0).transform.position;
        dragonBall.transform.gameObject.SetActive(true);
        dragonBallPoolController.dragonBallList[dragonBallLine].transform.DOMove(target.transform.position, 0.5f).OnComplete(() => dragonBallPoolController.DragonBallAddList(dragonBall));
        dragonBallPoolController.dragonBallList.RemoveAt(dragonBallLine);
    }

    void findNearEnemy()
    {
        distanceToClosestTarget = Mathf.Infinity;
        allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
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
}
