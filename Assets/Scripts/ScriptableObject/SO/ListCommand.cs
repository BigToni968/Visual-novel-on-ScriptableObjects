using System.Collections;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Command/" + nameof(ListCommand))]
    public class ListCommand : ScriptableObject
    {
        [SerializeField] private ScriptableObject[] _commands;

        public ScriptableObject[] Commands => _commands;
    }
}