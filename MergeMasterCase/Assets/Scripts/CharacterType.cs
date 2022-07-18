using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterType", menuName = "CharacterType")]
public class CharacterType : ScriptableObject
{
    public LayerMask characterLayerMask;
    public LayerMask gridLayerMask;
    public LayerMask enemyLayerMask;

    public float AttackTime;
    public float walkSpeed;
    public float characterHealth;

    public bool startGame;

    public string enemyTag;
    public string characterTag;


    private void OnEnable()
    {
        startGame = false;
    }
}
