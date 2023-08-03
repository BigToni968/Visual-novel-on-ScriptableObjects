using UnityEngine;
using System;

namespace Game.View
{
    public class ChoiseView : MonoBehaviour, ICommand
    {
        [SerializeField] private Canvas _self;
        [SerializeField] private Transform _parrent;
        [SerializeField] private ChoiseButton _prefabs;
        [SerializeField] private Commander _commander;

        public event Action<ICommand> End;

        private ChoiseButton tmp;

        public void Show() => _self.enabled = true;

        public void Add(Data.Choise.ChoiseElement[] choiseElement)
        {
            Show();

            for (int i = 0; i < choiseElement.Length; i++)
            {
                tmp = Instantiate(_prefabs, _parrent);
                tmp.Show(choiseElement[i], this);
            }
        }

        public void Onclick(int commandIndex)
        {
            End?.Invoke(this);
            Hide();
        }

        public void Hide() => _self.enabled = false;
    }
}