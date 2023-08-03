using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace Game.View
{
    public class BGView : MonoBehaviour, ICommand
    {
        [SerializeField] private Image _self;

        public event Action<ICommand> End;

        private Coroutine _fade;
        private WaitForSeconds _wait;
        private float _duration = 0f;
        private Color[] _colors = new Color[2] { new Color(1, 1, 1, 1), new Color(1, 1, 1, 0) };

        public void Show(Sprite source)
        {
            _self.sprite = source;
            _self.color = _colors[0];
            End?.Invoke(this);
        }

        public void ShowFade(Sprite sprite, float duration)
        {
            _self.color = _colors[1];
            _self.sprite = sprite;
            if (_fade != null)
                StopCoroutine(_fade);
            else
                StartCoroutine(Fade(_self, _colors[0], duration));
        }

        public void Hide()
        {
            _self.color = _colors[1];
            End?.Invoke(this);
        }

        public void HideFade(float duration)
        {
            if (_fade != null)
                StopCoroutine(_fade);
            else
                StartCoroutine(Fade(_self, _colors[1], duration));
        }

        private IEnumerator Fade(Image image, Color end, float duration)
        {
            float mili = duration / 100f;
            _wait ??= new WaitForSeconds(mili);
            if (duration != _duration)
            {
                _duration = duration;
                _wait = new WaitForSeconds(mili);
            }

            while (image.color != end)
            {
                image.color = new Color(end.r, end.g, end.b, image.color.a + (end.a > 0f ? mili : mili * -1));
                yield return _wait;
            }

            End?.Invoke(this);
        }
    }
}