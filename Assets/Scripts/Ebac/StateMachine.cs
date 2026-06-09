using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Ebac.StateMachine
{

    public class StateMachine <T> where T : System.Enum
    {
    
        public Dictionary<T,StateBase> dicionaryStates;
        private StateBase _currentState;
        public float TimetoStart = 1f;
   

        public StateBase currentState
        {
             get{ return _currentState;}
        }

        public void RegisterState( T TypeEnum, StateBase state)
        { 
            dicionaryStates.Add(TypeEnum, state);
        }

       
        public void Init()
        {
            dicionaryStates = new Dictionary<T, StateBase>();
        }

        public void SwitchState(T state)
        {
            if (_currentState != null) _currentState.OnStateExit();

            _currentState = dicionaryStates[state];
            _currentState.OnStateExit();

        }

        public void Update()
        {
            if (_currentState != null) _currentState.OnStateStay();    
        }
    }

}