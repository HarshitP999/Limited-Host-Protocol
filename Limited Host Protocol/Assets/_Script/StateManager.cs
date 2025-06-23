using UnityEngine;

public class StateManager 
{
    public PBase currentState;

    public void ChangerState(PBase newState)
    {
        currentState?.ExitState();
        currentState = newState;
        newState.EnterState();

    }
    public void UpdateState()
    {
        currentState?.Execute();
    }
}
