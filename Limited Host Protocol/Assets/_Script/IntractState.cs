using UnityEngine;
public class IntractState : PBase
{
    public PlayerController controller;

    public IntractState(PlayerController controller)
    {
        this.controller = controller;
    }

    public override void EnterState()
    {
        Debug.Log("Player is Intracting"); 

    }
    public override void Execute()
    {


        if(controller.moveInput == Vector2.zero)
        {
            controller.fsm.ChangerState(new IdlePlayer(controller));
        }

        if(controller.moveInput != Vector2.zero)
        {
            controller.fsm.ChangerState(new WalkPlayer(controller));
        }



    }
    public override void ExitState()
    {
     


    }

    
}
