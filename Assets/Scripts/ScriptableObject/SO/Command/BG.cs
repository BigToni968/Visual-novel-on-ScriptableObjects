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
        [SerializeField] private bool _isFade = false;
        [SerializeField] private float _duration;

        public Sprite Sprite => _sprite;
        public BgType Type => _type;
        public bool IsFade => _isFade;
        public float Duration => _duration;
    }
}