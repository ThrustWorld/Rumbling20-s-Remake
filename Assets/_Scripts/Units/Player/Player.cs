using UnityEngine;

public abstract class Player : UnitBase
{
    private bool _CanMove;

    private void Awake() => GameManager.OnBeforeStateChanged += OnStateChanged;

    private void OnDestroy() => GameManager.OnBeforeStateChanged -= OnStateChanged;

    private void OnStateChanged(GameState newState)
    {
        if(newState == GameState.Flow) _CanMove = true;    
    }

    private void OnMouseDown() 
    {   
        //Interactions only if it's hero turn
        if(GameManager.Instance.State != GameState.Flow) return;

        //Do not move if we've already done that
        if(!_CanMove) return;

        // Movement/Attack options

        //ExecuteMove => Move() - Attack() - Dafence()
        Debug.Log("Unit clicked");

    }

    public virtual void ExecuteMove()
    {
        //Override to do some hero-specific logic, then call base method to clean up the turn
        _CanMove = false;
    }
}