using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTurn : MonoBehaviour
{
    private TurnManager turnManager;

    public void StartTurn(TurnManager manager)
    {
        turnManager = manager;
        PerformAction();
    }

    private void PerformAction()
    {
        // Here you can define what the character does during their turn
        // For example, moving to a target, attacking, etc.

        // Simulating action with a delay
        StartCoroutine(ActionCoroutine());
    }

    private IEnumerator ActionCoroutine()
    {
        // Simulate an action taking time
        yield return new WaitForSeconds(2.0f);

        // End turn after the action is complete
        EndTurn();
    }

    private void EndTurn()
    {
        turnManager.EndTurn();
    }
}
