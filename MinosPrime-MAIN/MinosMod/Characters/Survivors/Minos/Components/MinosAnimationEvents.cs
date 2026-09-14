using MinosMod.Modules.BaseStates;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.Networking;

//personal notes: this is the reciever script for animation events from unity

namespace MinosMod.Characters.Survivors.Minos.Components
{
    public class MinosAnimationEvents : MonoBehaviour
    {
        public void TriggerBlink(float blinkSpeed)
        {
            EntityStateMachine[] stateMachines = transform.root.GetComponentsInChildren<EntityStateMachine>(true);

            foreach (EntityStateMachine stateMachine in stateMachines)
            {
                if (stateMachine.state is BaseMeleeAttack activeState)
                {
                    activeState.Blink(blinkSpeed);
                    Debug.Log("PlayableMinosPrime: Blink Triggered."); //for testing
                    return;
                } else
                {
                    if (stateMachine.state != null)
                    {
                        Debug.Log($"PlayableMinosPrime: Machine [{stateMachine.customName}] state type is: {stateMachine.state.GetType().FullName}");
                    }
                }
            }
        }



        //test method
        public void PrintDebugLog(string message)
        {
            Debug.Log("PlayableMinosPrime: If you're seeing this, animationevent is working :3 " + message);
        }
    }
}
