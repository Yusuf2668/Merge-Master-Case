using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallRepositoryController : MonoBehaviour
{
    public List<GameObject> enemyBallList;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            enemyBallList.Add(transform.GetChild(i).transform.gameObject);
        }
    }

    public void DragonBallAddList(GameObject _gameObject)
    {
        _gameObject.SetActive(false);
        enemyBallList.Add(_gameObject);
    }
}
