using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] CharacterType characterType;

    [SerializeField] GameObject playButton;

    public void StartGame()
    {
        characterType.startGame = true;
        playButton.SetActive(false);
    }
}
