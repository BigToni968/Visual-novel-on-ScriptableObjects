using UnityEngine;
using Game.View;
using Game.Data;

public class Commander : MonoBehaviour
{
    [Header("SO data")]
    [SerializeField] private ListCommand _listCommands;

    [Header("View")]
    [SerializeField] private Game.View.BG _commandBG;
    [SerializeField] private Say _commandSay;
    [SerializeField] private Game.View.Choise _commandChoise;
    [SerializeField] private Game.View.Character _commandCharacter;

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

            case Game.Data.BG bg:
                _commandBG.End += EndCommand;

                if (bg.Type == Game.Data.BgType.show) _commandBG.Show(bg.Sprite);
                else _commandBG.Hide();

                break;

            case Game.Data.Monologue monologue:
                _commandSay.End += EndCommand;

                _commandSay.Something(monologue);
                break;

            case Game.Data.Choise choise:
                _commandChoise.End += EndCommand;

                _commandChoise.Add(choise.Choises);
                break;

            case Game.Data.Character character:
                _commandCharacter.End += EndCommand;

                if (character.Type == CharacterType.Show)
                    _commandCharacter.Show(character.GetSprite);
                break;

            case Stop stop:
                stop.OnText();
                break;
        }
    }

    private void EndCommand(ICommand command)
    {
        command.End -= EndCommand;

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