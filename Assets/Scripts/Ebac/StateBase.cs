using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Ebac.StateMachine
{ 

    public class StateBase

    {
        public virtual void OnStateEnter(object o = null)
        {
            Debug.Log("OnStatetEnter");
        }

        public virtual void OnStateStay()
        {
            Debug.Log("OnStateStay");
        }

        public virtual void OnStateExit()
        {
            Debug.Log("OnStateExit");
        }
    }

}