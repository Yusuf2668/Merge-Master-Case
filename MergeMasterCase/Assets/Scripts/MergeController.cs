using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                level02CharacterList[0].gameObject.SetActive(true);
                level02CharacterList.RemoveAt(0);
                break;
            case 2:
                level03CharacterList[0].gameObject.transform.position = spawnPosiiton.position;
                level03CharacterList[0].gameObject.SetActive(true);
                level03CharacterList.RemoveAt(0);
                break;
            case 3:
                level04CharacterList[0].gameObject.transform.position = spawnPosiiton.position;
                level04CharacterList[0].gameObject.SetActive(true);
                level04CharacterList.RemoveAt(0);
                break;
        }
    }


}
