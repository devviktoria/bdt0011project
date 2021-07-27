using UnityEngine;
using UnityEngine.UIElements;

public class ScoreViewModel : MonoBehaviour
{
    private MessageBroker _messageBroker;

    private Label _currentAliensAtDoorLabel;
    private Label _currentKillCountLabel;
    private Label _gameOverLabel;
    private Label _winningTextLabel;
    private Label _loosingTextLabel;

    private StyleColor _redStyleColor;
    private StyleColor _yellowStyleColor;
    private StyleColor _greenStyleColor;

    private void Awake()
    {
        _redStyleColor = new StyleColor(Color.red);
        _yellowStyleColor = new StyleColor(new Color(1, 1, 0.2f, 1));
        _greenStyleColor = new StyleColor(new Color(0.2f, 0.8f, 0f, 1));

        UIDocument uiDocument = GetComponent<UIDocument>();
        _currentAliensAtDoorLabel = uiDocument.rootVisualElement.Query("CurrentAliensAtDoor").First() as Label;
        _currentKillCountLabel = uiDocument.rootVisualElement.Query("CurrentKillCount").First() as Label;
        _gameOverLabel = uiDocument.rootVisualElement.Query("GameOver").First() as Label;
        _winningTextLabel = uiDocument.rootVisualElement.Query("WinningText").First() as Label;
        _loosingTextLabel = uiDocument.rootVisualElement.Query("LoosingText").First() as Label;

        SetBorderColor(_currentKillCountLabel, _redStyleColor);
        SetBorderColor(_currentAliensAtDoorLabel, _greenStyleColor);

        _messageBroker = FindObjectOfType<MessageBrokerService>().MessageBroker;
        _messageBroker.AliensAtDoorUpdated.AddListener(AliensAtDoorUpdated);
        _messageBroker.KillCountUpdated.AddListener(KillCountUpdated);
        _messageBroker.GameOver.AddListener(GameOver);

    }

    private void OnDestroy()
    {
        _messageBroker.AliensAtDoorUpdated.RemoveListener(AliensAtDoorUpdated);
        _messageBroker.KillCountUpdated.RemoveListener(KillCountUpdated);
        _messageBroker.GameOver.RemoveListener(GameOver);
    }

    private void GameOver(bool isGameHasWon)
    {
        _gameOverLabel.style.display = DisplayStyle.Flex;
        if (isGameHasWon)
        {
            _winningTextLabel.style.display = DisplayStyle.Flex;
        }
        else
        {
            _loosingTextLabel.style.display = DisplayStyle.Flex;
        }
    }

    private void KillCountUpdated(int currentKillCount, int targetKillCount)
    {
        _currentKillCountLabel.text = currentKillCount.ToString();
        float percentage = (float)currentKillCount / targetKillCount;
        if (percentage > 0.8)
        {
            SetBorderColor(_currentKillCountLabel, _greenStyleColor);
        }
        else if (percentage > 0.5)
        {
            SetBorderColor(_currentKillCountLabel, _yellowStyleColor);
        }
        else
        {
            SetBorderColor(_currentKillCountLabel, _redStyleColor);
        }
    }

    private void AliensAtDoorUpdated(int currentAliensAtDoor, int maximumAllowedAliensAtDoor)
    {
        _currentAliensAtDoorLabel.text = currentAliensAtDoor.ToString();

        float percentage = (float)currentAliensAtDoor / maximumAllowedAliensAtDoor;
        if (percentage > 0.6)
        {
            SetBorderColor(_currentAliensAtDoorLabel, _redStyleColor);
        }
        else if (percentage > 0.3)
        {
            SetBorderColor(_currentAliensAtDoorLabel, _yellowStyleColor);
        }
        else
        {
            SetBorderColor(_currentAliensAtDoorLabel, _greenStyleColor);
        }
    }

    private void SetBorderColor(VisualElement element, StyleColor borderColor)
    {
        element.style.borderLeftColor = borderColor;
        element.style.borderRightColor = borderColor;
        element.style.borderTopColor = borderColor;
        element.style.borderBottomColor = borderColor;
    }

}