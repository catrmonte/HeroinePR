using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        Debug.Log("Entered Jumping!");
        player.mCurrentState = this;

        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0, 400 * Time.deltaTime, 0, ForceMode.VelocityChange);
    }

    public void Execute(Player player)
    {
        // If hit the ground
        if (Physics.Raycast(player.transform.position, Vector3.down, 0.55f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }

        // If presses S to dive
        if (Input.GetKeyDown(KeyCode.S))
        {
            // transition to diving
            DivingPlayerState divingState = new DivingPlayerState();
            divingState.Enter(player);
        }
    }
}
