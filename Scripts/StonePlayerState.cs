 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePlayerState : IPlayerState
{

    public void Enter(Player player)
    {
        Debug.Log("Entering Stone!");

        player.mCurrentState = this;
        player.GetComponent<MeshRenderer>().material = player.stone;
    }

    public void Execute(Player player)
    {
        // If presses X to transform back
        if (Input.GetKeyDown(KeyCode.X))
        {
            // transition to Standing
            player.GetComponent<MeshRenderer>().material = player.normal;

            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }

        // If presses B explodes
        if (Input.GetKeyDown(KeyCode.B))
        {
            // transition to PowerJump
            player.GetComponent<MeshRenderer>().material = player.burning;

            BurningPlayerState burningState = new BurningPlayerState();
            burningState.Enter(player);
        }
    }
}
