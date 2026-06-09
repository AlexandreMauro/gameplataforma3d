using UnityEngine;
using Core.Singelton;
using Ebac.StateMachine;


public class GameManager : Singelton<GameManager>
{
   public enum GameState
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }
    public StateMachine<GameState> gameState;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        gameState = new StateMachine<GameState>();
        gameState.Init();
        gameState.RegisterState(GameState.INTRO, new StateBase());
        gameState.RegisterState(GameState.GAMEPLAY, new StateBase());
        gameState.RegisterState(GameState.PAUSE, new StateBase());
        gameState.RegisterState(GameState.LOSE, new StateBase());
        gameState.RegisterState(GameState.WIN, new StateBase());

        gameState.SwitchState(GameState.INTRO);
    }
}
