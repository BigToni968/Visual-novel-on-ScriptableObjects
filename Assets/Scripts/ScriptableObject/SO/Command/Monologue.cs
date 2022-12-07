using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Command/" + nameof(Monologue))]
    public class Monologue : ScriptableObject
    {
        [Header("Name character")]
        [SerializeField] private string _name;
        [Header("Character Speech")]
        [SerializeField, TextArea(5, 10)] private string _text;

        public string Name => _name;
        public string Text => _text;
    }
}