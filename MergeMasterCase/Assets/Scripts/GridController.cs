using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] CharacterType characterType;

    Ray ray;
    RaycastHit characterHit;
    RaycastHit gridHit;

    GameObject selectedCharacter;
    GameObject previousCharacter;
    GameObject selectedGrid;


    void Update()
    {
        if (Input.touchCount > 0)
        {
            CharacterMove();
        }
        else
        {
            GridSelector();
        }
    }

    void CharacterMove()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out characterHit, Mathf.Infinity, characterType.characterLayerMask)) //karakterlerin hareketleri i�in at�lan ���n
        {
            selectedCharacter = characterHit.transform.gameObject;
            if (selectedCharacter == previousCharacter || previousCharacter == null)
            {
                previousCharacter = characterHit.transform.gameObject;
                previousCharacter.GetComponent<CharacterController>().canHit = true;
                previousCharacter.GetComponent<Collider>().isTrigger = true;
                previousCharacter.GetComponent<Rigidbody>().isKinematic = true;
                characterHit.transform.position = Vector3.MoveTowards(characterHit.transform.position, new Vector3(characterHit.point.x, characterHit.transform.position.y, characterHit.point.z), 1f);
                characterHit.transform.position = new Vector3(Mathf.Clamp(characterHit.transform.position.x, -3f, 3f), 1, Mathf.Clamp(characterHit.transform.position.z, -4.4f, 0.4f));
            }
        }
    }
    public void GridSelector()
    {
        if (selectedCharacter != null)
        {
            Debug.Log("ald�");
            if (Physics.Raycast(selectedCharacter.transform.position, Vector3.down, out gridHit, Mathf.Infinity, characterType.gridLayerMask) && !Physics.Raycast(selectedCharacter.transform.position, Vector3.down, Mathf.Infinity, characterType.characterLayerMask)) //se�ti�imiz karakterlerin karelere yerle�mesi i�in at�lan ���n
            {
                Debug.Log("b�rakt�");

                selectedGrid = gridHit.transform.gameObject;
                previousCharacter.GetComponent<Collider>().isTrigger = false;
                previousCharacter.GetComponent<Rigidbody>().isKinematic = false;
                if (!selectedCharacter.GetComponent<CharacterController>().canBackLastPosisiton)
                {
                    selectedCharacter.transform.position = new Vector3(selectedGrid.transform.position.x, selectedCharacter.transform.position.y, selectedGrid.transform.position.z);
                    selectedCharacter.GetComponent<CharacterController>().lastPosition = selectedGrid.transform.position;
                }
            }
            else
            {
                Debug.Log("b�rakmad�");

                selectedCharacter.GetComponent<CharacterController>().CallBackLastPosition();
            }
            selectedCharacter = null;
            previousCharacter = null;
        }
    }
}
