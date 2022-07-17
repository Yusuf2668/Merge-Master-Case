using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [HideInInspector] public bool canHit;
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
    public void RaycastToFindMergeCharacter()
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - 15, transform.position.z));
    }
    public void CallBackLastPosition()
    {
        transform.position = lastPosition;
    }

    void RaycastToFindGrid()
    {
        if (Physics.Raycast(transform.position + new Vector3(0, 2, 0), Vector3.down, out gridPositionHit, Mathf.Infinity, characterType.gridLayerMask))
        {
            transform.position = gridPositionHit.transform.position;
            lastPosition = transform.position;
        }
    }
}
