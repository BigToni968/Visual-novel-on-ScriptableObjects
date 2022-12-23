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

        public CharacterType Type => _type;

        public Sprite GetSprite => _storage.GetImage($"{_name}_{_number}");
    }

    public enum CharacterType
    {
        Show,
        Hide
    }
}