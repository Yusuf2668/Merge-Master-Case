using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] CharacterType characterType;

    [SerializeField] GameObject playButton;
    [SerializeField] GameObject grid;
    public void StartGame()
    {
        characterType.startGame = true;
        playButton.SetActive(false);
        grid.SetActive(false);
    }
}
