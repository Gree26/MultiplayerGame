using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Debugers
{
    public class DebugCommandBase
    {
        private string _commandId;
        private string _commandDescription;
        private string _commandFormat;

        public string commandId { get { return _commandId; } }
        public string commandDescription { get { return _commandDescription; } }
        public string commandFormat { get { return _commandFormat; } }

        public DebugCommandBase(string id, string description, string format)
        {
            _commandId = id;
            _commandDescription = description;
            _commandFormat = format;
        }
    }

    public class DebugCommand : DebugCommandBase
    {
        private Action command;

        public DebugCommand(string id, string description, string format, Action command) : base (id, description, format)
        {
            this.command = command;
        }

        public void Invoke()
        {
            command.Invoke();
        }
    }

    public class DebugCommand<T> : DebugCommandBase
    {
        private Action<T> command;

        public DebugCommand(string id, string description, string format, Action<T> command) : base(id, description, format)
        {
            this.command = command;
        }

        public void Invoke(T value)
        {
            command.Invoke(value);
        }
    }
}
