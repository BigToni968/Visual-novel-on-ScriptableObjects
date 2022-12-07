using UnityEngine;
using Game.Data;
using System;
using TMPro;

namespace Game.View
{
    public class Say : MonoBehaviour, ICommand
    {
        [SerializeField] private Commander _commander;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Choise _choise;

        [Header("Time write")]
        [SerializeField] private float _time;

        public event Action<ICommand> End;

        private Write _write;
        private Coroutine _coroutineWrite;


        private void Awake() => _write = new Write(_time);

        private void OnEnable()
        {
            _write.SelfWrite += Write;
        }

        private void OnDisable()
        {
            _write.SelfWrite -= Write;
        }

        private void Write(string str) => _text.SetText(str);

        public void Next() => Something(null);

        public void Something(Monologue monologue)
        {
            if (_write.SelfStatus == Game.Write.Status.Enabled)
            {
                StopCoroutine(_coroutineWrite);
                _write.SelfStatus = Game.Write.Status.Diabled;
            }

            if (monologue == null)
            {
                End?.Invoke(this);
                return;
            }

            if (_write.SelfStatus == Game.Write.Status.Diabled) _coroutineWrite = StartCoroutine(_write.Get(monologue.Text));

            _name.SetText(monologue.Name);

        }
    }
}