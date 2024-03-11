using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private int _scoreCounter;

    public event Action GameOver;
    public event Action<int> ScoreChanged;

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void IncreaseScore()
    {
        _scoreCounter++;
        ScoreChanged?.Invoke(_scoreCounter);
    }

    public void ResetBird()
    {
        _scoreCounter = 0;
        ScoreChanged?.Invoke(_scoreCounter);
        _birdMover.Reset();
    }

    public void DieBird()
    {
        GameOver?.Invoke();
    }
}
