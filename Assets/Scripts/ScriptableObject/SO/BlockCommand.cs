using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/" + nameof(BlockCommand))]
    public class BlockCommand : ScriptableObject
    {
        [SerializeField] private ScriptableObject[] _command;

        public ScriptableObject[] GetCommand => _command;
    }
}