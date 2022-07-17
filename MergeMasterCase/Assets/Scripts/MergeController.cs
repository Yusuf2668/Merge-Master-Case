using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MergeController : MonoBehaviour
{
    public List<GameObject> level01CharacterList;
    public List<GameObject> level02CharacterList;
    public List<GameObject> level03CharacterList;
    public List<GameObject> level04CharacterList;

    [SerializeField] CharacterType characterType;

    public void CharacterMerge(Transform spawnPosiiton, int _level)
    {
        switch (_level)
        {
            case 1:
                level02CharacterList[0].gameObject.transform.position = spawnPosiiton.position;
                level02CharacterList[0].gameObject.transform.SetParent(null);
                level02CharacterList[0].gameObject.SetActive(true);
                level02CharacterList[0].gameObject.transform.DOShakeScale(0.5f, 0.05f);
                level02CharacterList.RemoveAt(0);
                break;
            case 2:
                level03CharacterList[0].gameObject.transform.position = spawnPosiiton.position;
                level03CharacterList[0].gameObject.transform.SetParent(null);
                level03CharacterList[0].gameObject.SetActive(true);
                level03CharacterList[0].gameObject.transform.DOShakeScale(0.5f, 0.05f);
                level03CharacterList.RemoveAt(0);
                break;
            case 3:
                level04CharacterList[0].gameObject.transform.position = spawnPosiiton.position;
                level04CharacterList[0].gameObject.transform.SetParent(null);
                level04CharacterList[0].gameObject.SetActive(true);
                level04CharacterList[0].gameObject.transform.DOShakeScale(0.5f, 0.05f);
               level04CharacterList.RemoveAt(0);
                break;
        }
    }


}
