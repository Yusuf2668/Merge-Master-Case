using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBallPoolController : MonoBehaviour
{
    public List<GameObject> dragonBallList;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            dragonBallList.Add(transform.GetChild(i).transform.gameObject);
        }
    }

    public void DragonBallAddList(GameObject _gameObject)
    {
        _gameObject.SetActive(false);
        dragonBallList.Add(_gameObject);
    }
}
