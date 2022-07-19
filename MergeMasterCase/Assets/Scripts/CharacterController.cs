using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [HideInInspector] public bool canHit;
    [HideInInspector] public Vector3 lastPosition;

    [SerializeField] int _characterLevel;
    [SerializeField] CharacterType characterType;

    MergeController mergeController;

    RaycastHit mergeCharacterHit;
    RaycastHit gridPositionHit;

    Slider healthBar;

    private float _health;
    public int characterLevel
    {
        get { return _characterLevel; }
    }

    private void OnEnable()
    {
        healthBar = transform.GetChild(0).transform.GetChild(0).transform.gameObject.GetComponent<Slider>();
        _health = characterType.characterHealth * _characterLevel;
        healthBar.maxValue  = _health;
        healthBar.value = _health;
        canHit = true;
        mergeController = GameObject.FindObjectOfType<MergeController>();
        RaycastToFindGrid(); // baþlanðýçta ki pozisyonlarýný gridlere göre ayarlamak için 
    }

    private void Update()
    {
        if (canHit && Input.touchCount == 0)
        {
            RaycastToFindMergeCharacter();
            canHit = false;
        }
    }
    public void TakeDamage(float _damageValue)
    {
        _health -= characterLevel * 10;
        healthBar.value = _health;
        if (_health <= 0)
        {
            transform.gameObject.SetActive(false);
        }
    }
    private void RaycastToFindMergeCharacter()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out mergeCharacterHit, 20, characterType.characterLayerMask))
        {
            if (mergeCharacterHit.transform.tag == transform.tag && characterLevel == mergeCharacterHit.transform.gameObject.GetComponent<CharacterController>().characterLevel && characterLevel < 4)
            {
                mergeCharacterHit.transform.gameObject.SetActive(false);

                mergeController.CharacterMerge(mergeCharacterHit.transform, characterLevel);
                gameObject.SetActive(false);
            }
            else
            {
                CallBackLastPosition();
            }
        }
    }
    private void CallBackLastPosition()
    {
        transform.position = lastPosition;
    }
    private void RaycastToFindGrid()
    {
        if (Physics.Raycast(transform.position + new Vector3(0, 2, 0), Vector3.down, out gridPositionHit, Mathf.Infinity, characterType.gridLayerMask))
        {
            transform.position = gridPositionHit.transform.position;
            lastPosition = transform.position;
        }
    }


}
