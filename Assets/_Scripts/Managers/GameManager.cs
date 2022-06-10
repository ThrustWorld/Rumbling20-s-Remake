using UnityEngine;
using System;


// Manage the flow of the game and it's an enum-based game manager.

[Serializable]
public enum GameState
{
    Starting = 0,
    Flow = 1,
    Lose = 2,
}

public class GameManager : Singleton<GameManager>{
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State {get; private set;}

    // game starts with the first state
    void Start() => ChangeState(GameState.Starting);

    public void ChangeState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState); // do something before the change

        State = newState;
        switch(newState)
        {
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.Flow:
                HandleFlow();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState); // do something after the change

        Debug.Log($"New state: {newState}");
    }
    
    private void HandleStarting()
    {
        //Setup
        LevelGenerator.Instance.Initialize();
        ChangeState(GameState.Flow);
    }
    
    private void HandleFlow()
    {
        // Flow of the game => Check all the Update() methods
    }
    private void HandleLose()
    {
       // Do something if you lose 


    }
}
