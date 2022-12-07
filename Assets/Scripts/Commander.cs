using UnityEngine;
using Game.View;

public class Commander : MonoBehaviour
{
    [Header("SO data")]
    [SerializeField] private Game.Data.ListCommand _listCommands;

    [Header("View")]
    [SerializeField] private BG _commandBG;
    [SerializeField] private Say _commandSay;
    [SerializeField] private Choise _commandChoise;

    private int _indexCommand = 0;
    private ScriptableObject _curentCommand;

    private void Start() => ExecuteCommand();

    public void ExecuteCommand()
    {
        _curentCommand = _listCommands.Commands[_indexCommand];

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

            case Game.Data.Stop stop:
                stop.OnText();
                break;
        }
    }

    private void EndCommand(ICommand command)
    {
        command.End -= EndCommand;

        if (_indexCommand < _listCommands.Commands.Length - 1)
        {
            _indexCommand++;
            ExecuteCommand();
        }
    }
}