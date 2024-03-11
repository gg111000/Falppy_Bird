using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        Time.timeScale = 0;
        _startScreen.Open();
        _pauseButton.interactable = false;
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
        _pauseButton.interactable = false;
        _audioSource.Stop();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _pipeGenerator.ResetPool();
        _pauseButton.interactable = true;
        _audioSource.Play();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        _pauseButton.interactable = true;
        _audioSource.Play();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetBird();
    }
}
