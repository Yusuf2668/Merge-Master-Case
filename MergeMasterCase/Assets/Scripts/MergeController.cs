using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeController : MonoBehaviour
{
    public List<GameObject> characterList;

    [SerializeField] CharacterType characterType;

    public void CharacterMerge(Transform spawnPosiiton, int _level)
    {
        Instantiate(characterList[_level], spawnPosiiton.position, Quaternion.identity);
    }
}
