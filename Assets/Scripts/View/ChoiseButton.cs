using UnityEngine.UI;
using UnityEngine;
using Game.Data;
using TMPro;

namespace Game.View
{
    public class ChoiseButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Button _self;

        public void Show(Choise.ChoiseElement choiseElement, ChoiseView choise)
        {
            _text.SetText(choiseElement.Text);
            _self.onClick.AddListener(() => choise.Onclick(choiseElement.Goto));
        }

        public void Hide() => Destroy(gameObject);
    }
}