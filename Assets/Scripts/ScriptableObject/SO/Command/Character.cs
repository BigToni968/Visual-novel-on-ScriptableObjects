using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Command/" + nameof(Character))]
    public class Character : ScriptableObject
    {
        [Header("Storage images")]
        [SerializeField] private StorageImage _storage;
        [Header("Name Character in Storage")]
        [SerializeField] private string _name;
        [SerializeField] private bool _isFade = false;
        [SerializeField] private float _duration;
        [Header("Number sprite")]
        [SerializeField] private int _number;
        [SerializeField] private CharacterType _type;
        [SerializeField] private View.CharacterView.Stage.StageType _stageStartPos;
        [SerializeField] private View.CharacterView.Stage.StageType _stageEndPos;

        public CharacterType Type => _type;

        public CharacterTemplate Get => new CharacterTemplate(_name, _isFade, _duration, _type, _stageStartPos, _stageEndPos, _storage.GetImage($"{_name}_{_number}"));
    }

    public struct CharacterTemplate
    {
        private string _name;
        private bool _isFade;
        private float _duration;
        private CharacterType _characterType;
        private View.CharacterView.Stage.StageType _stageStartPos;
        private View.CharacterView.Stage.StageType _stageEndPos;
        private Sprite _sprite;

        public string Name => _name;
        public bool IsFade => _isFade;
        public float Duration => _duration;
        public CharacterType CharacterType => _characterType;
        public View.CharacterView.Stage.StageType StageStartPos => _stageStartPos;
        public View.CharacterView.Stage.StageType StageEndPos => _stageEndPos;
        public Sprite Sprite => _sprite;

        public CharacterTemplate(string name, bool isFade, float duration, CharacterType characterType, View.CharacterView.Stage.StageType stageTypeStartPos, View.CharacterView.Stage.StageType stageTypeEndPos, Sprite sprite)
        {
            _name = name;
            _isFade = isFade;
            _duration = duration;
            _characterType = characterType;
            _stageStartPos = stageTypeStartPos;
            _stageEndPos = stageTypeEndPos;
            _sprite = sprite;
        }
    }

    public enum CharacterType
    {
        Show,
        Hide,
        Move,
        ShowAndMove,
        MoveAndHide
    }
}