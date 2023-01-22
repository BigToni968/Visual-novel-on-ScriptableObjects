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
        [Header("Number sprite")]
        [SerializeField] private int _number;
        [SerializeField] private CharacterType _type;
        [SerializeField] private View.Character.Stage.StageType _stageStartPos;
        [SerializeField] private View.Character.Stage.StageType _stageEndPos;

        public CharacterType Type => _type;

        public CharacterTemplate Get => new CharacterTemplate(_name, _type, _stageStartPos, _stageEndPos, _storage.GetImage($"{_name}_{_number}"));
    }

    public struct CharacterTemplate
    {
        private string _name;
        private CharacterType _characterType;
        private View.Character.Stage.StageType _stageStartPos;
        private View.Character.Stage.StageType _stageEndPos;
        private Sprite _sprite;

        public string Name => _name;
        public CharacterType CharacterType => _characterType;
        public View.Character.Stage.StageType StageStartPos => _stageStartPos;
        public View.Character.Stage.StageType StageEndPos => _stageEndPos;
        public Sprite Sprite => _sprite;

        public CharacterTemplate(string name, CharacterType characterType, View.Character.Stage.StageType stageTypeStartPos, View.Character.Stage.StageType stageTypeEndPos, Sprite sprite)
        {
            _name = name;
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