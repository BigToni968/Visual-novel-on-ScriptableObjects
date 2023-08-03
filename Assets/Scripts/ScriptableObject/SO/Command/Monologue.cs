using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Command/" + nameof(Monologue))]
    public class Monologue : ScriptableObject
    {
        [Header("Name character")]
        [SerializeField] private string _name;
        [Header("Color name")]
        [SerializeField] private Color _colorName = new Color(1, 1, 1, 1);
        [Header("Color speach")]
        [SerializeField] private Color _colorSpeach = new Color(1, 1, 1, 1);
        [Header("Character Speech")]
        [SerializeField, TextArea(5, 10)] private string _text;

        public string Name => _name;
        public string Text => _text;
        public Color ColorName => _colorName;
        public Color ColorSpeach => _colorSpeach;
    }
}