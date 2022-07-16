using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool canHit;

    [SerializeField] int _characterLevel;
    [SerializeField] CharacterType characterType;

    MergeController mergeController;

    RaycastHit hit;

    public int characterLevel
    {
        get { return _characterLevel; }
        set
        {
            if (value > 0 && value < 5)
            {
                _characterLevel = value;
            }
        }
    }

    private void Start()
    {
        mergeController = GameObject.FindObjectOfType<MergeController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grid")) //baþlangýötaki konumlarýný griplerin içine göre ayarlýyor
        {
            gameObject.transform.position = new Vector3(other.transform.position.x, gameObject.transform.position.y, other.transform.position.z);
        }
    }

    private void Update()
    {
        if (canHit && Input.touchCount == 0)
        {
            StartRaycast();
            canHit = false;
        }
    }

    public void StartRaycast()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, characterType.characterLayerMask))
        {
            if (hit.transform.tag == transform.tag && characterLevel == hit.transform.gameObject.GetComponent<CharacterController>().characterLevel)
            {
                hit.transform.gameObject.SetActive(false);
                mergeController.CharacterMerge(hit.transform, characterLevel);
                gameObject.SetActive(false);
            }
        }
    }
}
