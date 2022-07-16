using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [HideInInspector] public bool canHit;
    [HideInInspector] public bool canBackLastPosisiton;
    [HideInInspector] public Vector3 lastPosition;

    [SerializeField] int _characterLevel;
    [SerializeField] CharacterType characterType;

    MergeController mergeController;

    RaycastHit mergeCharacterHit;
    RaycastHit gridPositionHit;

    public int characterLevel
    {
        get { return _characterLevel; }
    }

    private void OnEnable()
    {
        canHit = true;
        canBackLastPosisiton = false;
        mergeController = GameObject.FindObjectOfType<MergeController>();
        lastPosition = transform.position;
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

    public void RaycastToFindMergeCharacter()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out mergeCharacterHit, Mathf.Infinity, characterType.characterLayerMask))
        {
            if (mergeCharacterHit.transform.tag == transform.tag && characterLevel == mergeCharacterHit.transform.gameObject.GetComponent<CharacterController>().characterLevel && characterLevel < 4)
            {
                canBackLastPosisiton = false;
                mergeCharacterHit.transform.gameObject.SetActive(false);
                mergeController.CharacterMerge(mergeCharacterHit.transform, characterLevel);
                gameObject.SetActive(false);
            }
            else
            {
                canBackLastPosisiton = true;
                CallBackLastPosition();
            }
        }
    }
    public void CallBackLastPosition()
    {
        transform.position = lastPosition;
    }

    void RaycastToFindGrid()
    {
        if (Physics.Raycast(transform.position + new Vector3(0, 5, 0), Vector3.down, out gridPositionHit, Mathf.Infinity, characterType.gridLayerMask))
        {
            transform.position = gridPositionHit.transform.position;
        }
    }
}
