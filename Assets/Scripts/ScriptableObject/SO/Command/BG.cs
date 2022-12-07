using UnityEngine;

namespace Game.Data
{
    public enum BgType
    {
        show,
        hide
    }

    [CreateAssetMenu(menuName = "Game/Data/Command/" + nameof(BG))]
    public class BG : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private BgType _type = BgType.show;

        public Sprite Sprite => _sprite;
        public BgType Type => _type;
    }
}