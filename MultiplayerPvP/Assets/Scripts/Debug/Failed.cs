using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Debugers
{
    /// <summary>
    /// Handles fail messages. 
    /// </summary>
    public class Failed
    {
        /// <summary>
        /// Called when an action has failed. 
        /// </summary>
        public static Action<Failed> ActionFailed;

        private string _failMessage;

        public Failed(string failMessage)
        {
            _failMessage = failMessage;
        }

        public string FailMessage()
        {
            return _failMessage;
        }

        public void ThisActionFailed()
        {
            ActionFailed?.Invoke(this);
        }
    }
}
