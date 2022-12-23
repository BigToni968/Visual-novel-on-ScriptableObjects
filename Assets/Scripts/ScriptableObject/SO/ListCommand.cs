using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Command/" + nameof(ListCommand))]
    public class ListCommand : ScriptableObject
    {
        [SerializeField] private BlockCommand[] _blocks;

        public BlockCommand[] Blocks => _blocks;
    }
}