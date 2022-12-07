using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Command/" + nameof(Stop))]
    public class Stop : ScriptableObject
    {
        public void OnText() => Debug.Log("Stop command!");
    }
}