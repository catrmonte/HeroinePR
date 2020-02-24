using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        Debug.Log("Entered Standing!");
        player.GetComponent<MeshRenderer>().material = player.normal;
        player.mCurrentState = this;
    }

    public void Execute (Player player)
    {
        // If player presses s, transition to ducking
        if (Input.GetKeyDown(KeyCode.S))
        {
            // transition to ducking
            DuckingPlayerState duckingState = new DuckingPlayerState();
            duckingState.Enter(player);
        }

        // If player presses x, transition to Stone state
        if (Input.GetKeyDown(KeyCode.X))
        {
            // transition to Stone
            StonePlayerState stoneState = new StonePlayerState();
            stoneState.Enter(player);
        }

        // If presses space from standing, jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpingPlayerState jumpingState = new JumpingPlayerState();
            jumpingState.Enter(player);
        }
    }
}
