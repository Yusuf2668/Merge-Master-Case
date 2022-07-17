using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterType", menuName = "CharacterType")]
public class CharacterType : ScriptableObject
{
    public LayerMask characterLayerMask;
    public LayerMask gridLayerMask;

}
