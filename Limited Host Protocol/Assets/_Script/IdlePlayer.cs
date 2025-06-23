using UnityEngine;

public class IdlePlayer : PBase
{
    public PlayerController playerControl;

    public IdlePlayer(PlayerController player)
    {
        this.playerControl = player;
    }

    public override void EnterState()
    {
       
    }
    public override void Execute()
    {
        if (playerControl.moveInput != Vector2.zero)
        {
            Debug.Log("Change to walk State");
            playerControl.fsm.ChangerState(new WalkPlayer(playerControl));
        }
    }

    public override void ExitState()
    {
    }

   
}
