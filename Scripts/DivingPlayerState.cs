using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        Debug.Log("Entered Diving!");
        player.mCurrentState = this;

        Rigidbody rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0, -1000 * Time.deltaTime, 0, ForceMode.VelocityChange);
    }

    public void Execute(Player player)
    {
        // If hit the ground
        if (Physics.Raycast(player.transform.position, Vector3.down, 0.55f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}
