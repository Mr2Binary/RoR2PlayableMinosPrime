using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace MinosMod.Characters.Survivors.Minos.Components
{
    public class MinosAnimationEvents : MonoBehaviour
    {
        public void PrintDebugLog(string message)
        {
            Debug.Log("PlayableMinosPrime: If you're seeing this, animationevent is working :3 " + message);
        }
    }
}
