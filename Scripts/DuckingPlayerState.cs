using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        Debug.Log("Entered Ducking!");
        player.mCurrentState = this;

        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.transform.localScale *= 0.5f;
    }

    public void Execute(Player player)
    {
        // If player releases s...
        if (!Input.GetKey(KeyCode.S))
        {
            // transition to standing
            StandingPlayerState standingState = new StandingPlayerState();
            Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
            rbPlayer.transform.localScale *= 2f;
            standingState.Enter(player);
        }

        // If presses space...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Power Jump
            Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
            rbPlayer.transform.localScale *= 2f;

            PowerJumpingPlayerState powerJumpingState = new PowerJumpingPlayerState();
            powerJumpingState.Enter(player);
        }
    }
}
