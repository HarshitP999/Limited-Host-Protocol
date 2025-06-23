using UnityEngine;

public class WalkPlayer : PBase
{
    public PlayerController playerController;

    public WalkPlayer(PlayerController playerControl)
    {
        this.playerController = playerControl;
    }

    public override void EnterState()
    {
      
    }

    public override void Execute()
    {
        if (playerController.moveInput == Vector2.zero) 
        {
            Debug.Log("Idle State");
            playerController.fsm.ChangerState(new IdlePlayer(playerController));

        }
    }

    public override void ExitState()
    {


    }
}
