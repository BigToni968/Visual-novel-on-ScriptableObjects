using UnityEngine;
using Game.View;
using Game.Data;

public class Commander : MonoBehaviour
{
    [Header("SO data")]
    [SerializeField] private ListCommand _listCommands;

    [Header("View")]
    [SerializeField] private BGView _commandBG;
    [SerializeField] private SayView _commandSay;
    [SerializeField] private ChoiseView _commandChoise;
    [SerializeField] private CharacterView _commandCharacter;

    private int _indexCommand = 0;
    private int _indexBlockCommand = 0;
    private ScriptableObject _curentCommand;
    private BlockCommand _curentBlock;

    private void Start() => ExecuteCommand();

    public void ExecuteCommand()
    {
        _curentBlock ??= _listCommands.Blocks[_indexBlockCommand];
        _curentCommand = _curentBlock.GetCommand[_indexCommand];

        switch (_curentCommand)
        {
            default:
                Debug.Log($"Unknown command, type of command {_curentCommand.GetType().Name}");
                break;

            case BG bg:
                _commandBG.End += EndCommand;

                if (bg.Type == BgType.show)
                {
                    if (bg.IsFade && bg.Duration > 0f)
                        _commandBG.ShowFade(bg.Sprite, bg.Duration);
                    else
                        _commandBG.Show(bg.Sprite);
                }
                else
                {
                    if (bg.IsFade && bg.Duration > 0f)
                        _commandBG.HideFade(bg.Duration);
                    else
                        _commandBG.Hide();
                }
                break;

            case Monologue monologue:
                _commandSay.End += EndCommand;

                _commandSay.Something(monologue);
                break;

            case Choise choise:
                _commandChoise.End += EndCommand;

                _commandChoise.Add(choise.Choises);
                break;

            case Character character:
                _commandCharacter.End += EndCommand;
                _commandCharacter.Execute(character.Get);
                break;

            case Stop stop:
                stop.OnText();
                break;
        }
    }

    private void EndCommand(ICommand command)
    {
        command.End -= EndCommand;

        ChoiseView choiseCommand = command as ChoiseView;

        if (choiseCommand != null)
        {
            _indexCommand = choiseCommand.LastChoiseIndex;
        }

        if (_indexCommand < _curentBlock.GetCommand.Length - 1)
        {
            _indexCommand++;
            ExecuteCommand();
        }
        else if (_indexBlockCommand < _listCommands.Blocks.Length - 1)
        {
            _indexCommand = 0;
            _indexBlockCommand++;
            _curentBlock = null;
            ExecuteCommand();
        }
    }
}