using System.Collections.Generic;
using UnityEngine;
using Game.Data;
using System;

namespace Game.View
{
    public class ChoiseView : MonoBehaviour, ICommand
    {
        [SerializeField] private Canvas _self;
        [SerializeField] private Transform _parrent;
        [SerializeField] private ChoiseButton _prefabs;

        public event Action<ICommand> End;
        public int LastChoiseIndex = -1;
        private List<ChoiseButton> _choiseButtons = new List<ChoiseButton>();

        public void Show() => _self.enabled = true;

        public void Add(Choise.ChoiseElement[] choiseElement)
        {
            _choiseButtons ??= new List<ChoiseButton>(choiseElement.Length);

            for (int i = 0; i < choiseElement.Length; i++)
            {
                ChoiseButton tmp = Instantiate(_prefabs, _parrent);
                tmp.Show(choiseElement[i], this);
                _choiseButtons.Add(tmp);
            }
            Show();
        }

        public void Onclick(int commandIndex)
        {
            LastChoiseIndex = commandIndex - 1;
            End?.Invoke(this);
            Hide();
        }

        public void Hide()
        {
            for (int i = _choiseButtons.Count - 1; i >= 0; i--)
            {
                _choiseButtons[i].Hide();
            }
            _choiseButtons.Clear();
            _self.enabled = false;
        }
    }
}