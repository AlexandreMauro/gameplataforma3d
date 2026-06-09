using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Ebac.StateMachine;
public class FSMExample : MonoBehaviour
{
   public enum ExampleEnum
    {
        STATE_01,
        STATE_02,
        STATE_03
    }

    
    public StateMachine<ExampleEnum> stateMachine;


    private void Start()
    {
        stateMachine = new StateMachine<ExampleEnum>();
        stateMachine.Init();
        stateMachine.RegisterState(ExampleEnum.STATE_01, new StateBase());
        stateMachine.RegisterState(ExampleEnum.STATE_02, new StateBase());
        stateMachine.RegisterState(ExampleEnum.STATE_03, new StateBase());
    }
}
