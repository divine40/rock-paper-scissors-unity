using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour
{
    public Button rockButton, paperButton, scissorsButton, shootButton, replayButton;
    public TextMeshProUGUI playerChoiceText, computerChoiceText, resultText;
    public TextMeshProUGUI playerScoreText, computerScoreText, tieScoreText;

    private string playerChoice;
    private string computerChoice;

    private int playerScore = 0;
    private int computerScore = 0;
    private int tieScore = 0;

    private List<string> choices = new List<string> { "Rock", "Paper", "Scissors" };

    void Start()
    {
        shootButton.onClick.AddListener(PlayRound);
        replayButton.onClick.AddListener(ResetGame);

        rockButton.onClick.AddListener(() => SetPlayerChoice("Rock"));
        paperButton.onClick.AddListener(() => SetPlayerChoice("Paper"));
        scissorsButton.onClick.AddListener(() => SetPlayerChoice("Scissors"));

        ResetGame();
    }

    void SetPlayerChoice(string choice)
    {
        playerChoice = choice;
        playerChoiceText.text = "You chose: " + playerChoice;
    }

    void PlayRound()
    {
        if (string.IsNullOrEmpty(playerChoice)) return;

        // Anti-cheat: disable shoot and player buttons
        shootButton.interactable = false;
        rockButton.interactable = false;
        paperButton.interactable = false;
        scissorsButton.interactable = false;

        computerChoice = GetSmartComputerChoice(playerChoice);
        computerChoiceText.text = "Computer chose: " + computerChoice;

        string result = GetResult(playerChoice, computerChoice);
        resultText.text = result;

        UpdateScores(result);

        // Enable Replay
        replayButton.gameObject.SetActive(true);
    }

    string GetResult(string player, string computer)
    {
        if (player == computer) return "It's a Tie!";
        if ((player == "Rock" && computer == "Scissors") ||
            (player == "Paper" && computer == "Rock") ||
            (player == "Scissors" && computer == "Paper"))
        {
            return "You Win!";
        }
        else return "You Lose!";
    }

    void UpdateScores(string result)
    {
        if (result == "You Win!")
            playerScore++;
        else if (result == "You Lose!")
            computerScore++;
        else
            tieScore++;

        playerScoreText.text = "Player: " + playerScore;
        computerScoreText.text = "Computer: " + computerScore;
        tieScoreText.text = "Ties: " + tieScore;
    }

    void ResetGame()
    {
        playerChoice = "";
        computerChoice = "";

        resultText.text = "";
        playerChoiceText.text = "You chose: ";
        computerChoiceText.text = "Computer chose: ";

        shootButton.interactable = true;
        rockButton.interactable = true;
        paperButton.interactable = true;
        scissorsButton.interactable = true;

        replayButton.gameObject.SetActive(false);
    }

    string GetSmartComputerChoice(string player)
    {
        // Slightly increase difficulty by favoring winning moves 30% of the time
        float rand = Random.value;
        if (rand < 0.3f)
        {
            // Pick a counter move
            switch (player)
            {
                case "Rock": return "Paper";
                case "Paper": return "Scissors";
                case "Scissors": return "Rock";
            }
        }

        // Otherwise, pick randomly
        return choices[Random.Range(0, choices.Count)];
    }
}
