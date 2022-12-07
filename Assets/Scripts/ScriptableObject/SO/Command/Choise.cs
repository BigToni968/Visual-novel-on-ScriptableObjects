using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Command/" + nameof(Choise))]
    public class Choise : ScriptableObject
    {
        [System.Serializable]
        public class ChoiseElement
        {
            [SerializeField] private string _text;
            [SerializeField] private int _goto;

            public string Text => _text;
            public int Goto => _goto;
        }

        [SerializeField] private ChoiseElement[] _choises;

        public ChoiseElement[] Choises => _choises;
    }

}
