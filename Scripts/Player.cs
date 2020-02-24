using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IPlayerState mCurrentState;
    public Material stone;
    public Material normal;
    public Material burning;

    // Start is called before the first frame update
    void Start()
    {
        mCurrentState = new StandingPlayerState();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mCurrentState.Execute(this);
    }
}
