using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<CharacterTurn> characters; // List of all characters that take turns
    private int currentTurnIndex = 0;

    void Start()
    {
        if (characters.Count > 0)
        {
            StartTurn();
        }
    }

    public void StartTurn()
    {
        if (currentTurnIndex < characters.Count)
        {
            characters[currentTurnIndex].StartTurn(this);
        }
    }

    public void EndTurn()
    {
        currentTurnIndex = (currentTurnIndex + 1) % characters.Count;
        StartTurn();
    }
}
