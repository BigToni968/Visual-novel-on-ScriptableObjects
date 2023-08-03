using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System;

namespace Game.View
{
    public class CharacterView : MonoBehaviour, ICommand
    {
        [SerializeField] private float _timeCorotinue;
        [SerializeField] private Image _prefab;
        [SerializeField] private Stage _stage;

        public event Action<ICommand> End;

        private WaitForSeconds _wait;

        private Color[] _colors = new Color[2] { new Color(1, 1, 1, 1), new Color(1, 1, 1, 0) };

        private List<CharacterActive> _characters = new List<CharacterActive>();

        [Serializable]
        public class Stage
        {
            [SerializeField] private Transform _left;
            [SerializeField] private Transform _right;
            [SerializeField] private Transform _center;

            public enum StageType
            {
                Center,
                Left,
                Right
            }

            public Transform Get(StageType stage)
            {
                return stage switch
                {
                    StageType.Center => _center,
                    StageType.Right => _right,
                    StageType.Left => _left,
                    _ => null
                };
            }
        }

        private class CharacterActive
        {
            private Image _self;
            public Image Self => _self;
            public Data.CharacterTemplate template;

            public CharacterActive(Image image) => _self = image;
        }

        private CharacterActive isNewCharacter(Data.CharacterTemplate characterTemplate)
        {
            CharacterActive findCharacter = _characters.SingleOrDefault(character => character.template.Name == characterTemplate.Name);

            if (findCharacter == null)
            {
                findCharacter = new CharacterActive(Instantiate(_prefab, _stage.Get(characterTemplate.StageStartPos)));
                findCharacter.template = characterTemplate;
                findCharacter.Self.name = findCharacter.template.Name;
                _characters.Add(findCharacter);
                return findCharacter;
            }

            findCharacter.template = characterTemplate;
            return findCharacter;
        }

        public void Execute(Data.CharacterTemplate characterTemplate)
        {
            CharacterActive characterActive = isNewCharacter(characterTemplate);

            switch (characterTemplate.CharacterType)
            {
                default:
                    break;
                case Data.CharacterType.Show:
                    Show(characterActive.Self, characterTemplate.Sprite, _stage.Get(characterActive.template.StageStartPos));
                    End?.Invoke(this);
                    break;
                case Data.CharacterType.Hide:
                    Hide(characterActive.Self);
                    End?.Invoke(this);
                    break;
                case Data.CharacterType.Move:
                    StartCoroutine(Move(characterActive.Self.transform, _stage.Get(characterActive.template.StageEndPos), characterActive.template.CharacterType));
                    break;
                case Data.CharacterType.ShowAndMove:
                    Show(characterActive.Self, characterTemplate.Sprite, _stage.Get(characterActive.template.StageStartPos));
                    StartCoroutine(Move(characterActive.Self.transform, _stage.Get(characterActive.template.StageEndPos), characterActive.template.CharacterType));
                    break;
                case Data.CharacterType.MoveAndHide:
                    StartCoroutine(Move(characterActive.Self.transform, _stage.Get(characterActive.template.StageEndPos), characterActive.template.CharacterType));
                    break;
            }
        }

        public void Show(Image character, Sprite characterSprite, Transform newPos)
        {
            character.sprite = characterSprite;
            character.transform.parent = newPos;
            character.transform.position = newPos.position;
            character.color = _colors[0];
        }

        public IEnumerator Move(Transform start, Transform end, Data.CharacterType type)
        {
            start.parent = end;

            _wait ??= new WaitForSeconds(_timeCorotinue);

            while (Vector2.Distance(start.position, end.position) > 1f)
            {
                start.position = Vector3.Lerp(start.position, end.position, 0.05f);
                yield return _wait;
            }

            if (type == Data.CharacterType.MoveAndHide)
                Hide(start.GetComponent<Image>());

            End?.Invoke(this);

        }

        public void Hide(Image character)
        {
            character.color = _colors[1];
            character.sprite = null;
        }
    }
}