using UnityEngine.UI;
using UnityEngine;
using System;

namespace Game.View
{
    public class Character : MonoBehaviour, ICommand
    {
        [SerializeField] private Image _self;

        public event Action<ICommand> End;

        private Color[] _colors = new Color[2] { new Color(1, 1, 1, 1), new Color(1, 1, 1, 0) };


        public void Show(Sprite characterSprite)
        {
            _self.sprite = characterSprite;
            _self.color = _colors[0];
            End?.Invoke(this);
        }

        public void Hide()
        {
            _self.color = _colors[1];
            _self.sprite = null;
            End?.Invoke(this);
        }
    }
}