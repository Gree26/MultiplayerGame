using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Debugers
{
    public class DebugController : MonoBehaviour
    {
        bool displayConsole = false;
        bool showHelp = false;

        string input = "";
        private List<string> output = new List<string>();

        public static DebugCommand HELP;
        public static DebugCommand CLEAR;
        public static DebugCommand<string> DEBUG_LOG;

        public List<object> commandList;

        private string previousCommand = "";

        private List<string> previousCommands = new List<string>();
        private int position = 0;

        public static DebugController Instance { get; private set; }
        

        /// <summary>
        /// Execute to switch between showing and hiding the console 
        /// </summary>
        /// <param name="input"></param>
        public void OnDebugToggle(InputValue input)
        {
            displayConsole = !displayConsole;
            this.input = "";
        }

        /// <summary>
        /// To be called when return is pressed and if the console is open.
        /// </summary>
        /// <param name="input"></param>
        private void OnReturn(InputValue input)
        {
            float lineHeight = 20;

            if (displayConsole)
            {
                HandleInput();
                if (this.input != "") { previousCommands.Add(this.input); }
                this.position = previousCommands.Count;
                this.input = "";
                scroll = new Vector2(0, lineHeight * this.output.Count);
            }
        }

        private void OnUp(InputValue input)
        {
            if (displayConsole&&position!=0)
            {
                position--;
                this.input = previousCommands[position];
            }
        }

        private void OnDown(InputValue input)
        {
            if (displayConsole&&position!=previousCommands.Count)
            {
                position++;
                this.input = (position != previousCommands.Count)?previousCommands[position] : string.Empty;
            }
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                UnityEngine.Debug.LogError("TOO MANY DEBUG CONTRTOLLERS! Destroying this one");
            }

            HELP = new DebugCommand("help", "Shows Commands", "help", () =>
            {
                for (int i = 0; i < commandList.Count; i++)
                {
                    DebugCommandBase command = commandList[i] as DebugCommandBase;

                    string label = $"{command.commandFormat} - {command.commandDescription}";

                    NewOutput(label);
                }
            });

            CLEAR = new DebugCommand("clear", "Clears the console of all logs.", "clear", () =>
            {
                output.Clear();
                NewOutput("TYPE '" + HELP.commandId + "' TO SEE A LIST OF COMMANDS!");
            });

            DEBUG_LOG = new DebugCommand<string>("debug_log", "Prints whatever is given to the log.", "debug_log <text>", (x) =>
            {
                UnityEngine.Debug.Log(x);
                NewOutput("PRINTED TO LOG!");
            });

            commandList = new List<object>
            {
                HELP,
                CLEAR,
                DEBUG_LOG,
            };

            NewOutput("TYPE '" + HELP.commandId + "' TO SEE A LIST OF COMMANDS!");
        }

        public void NewOutput(string output)
        {
            this.output.Add(output);
        }

        Vector2 scroll;

        private void OnGUI()
        {
            if(!displayConsole) { return; }

            float y = 0;
            float historyLength = 200;
            float lineHeight = 20;
            float inputFieldHeight = 10;
            float verticalSpacing = 30;
            float padding = 5;


            GUI.Box(new Rect(0, y, Screen.width, historyLength), "");

            Rect viewport = new Rect(0, 0, Screen.width - verticalSpacing, lineHeight * this.output.Count);

            scroll = GUI.BeginScrollView(new Rect(0, y + padding, Screen.width, historyLength - inputFieldHeight), scroll, viewport, false, true);

            for (int i = 0; i < output.Count; i++)
            {
                Rect labelRect = new Rect(5, lineHeight * i, viewport.width - historyLength, lineHeight);

                GUI.Label(labelRect, output[i]);
            }

            GUI.EndScrollView();

            y += historyLength;

            GUI.Box(new Rect(0, y, Screen.width, 30), "");
            GUI.backgroundColor = Color.black;
            input = GUI.TextField(new Rect(10f, y + 5f, Screen.width-20f, 20f),input);
        }

        /// <summary>
        /// Execute any commands that may be in the input field
        /// </summary>
        private void HandleInput()
        {
            string[] inputValues = input.Split(' ');

            bool commandFound = false;

            for(int i=0; i< commandList.Count; i++)
            {
                DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

                if (input.Contains(commandBase.commandId))
                {
                    if(commandList[i] as DebugCommand != null)
                    {
                        (commandList[i] as DebugCommand).Invoke();
                    }
                    else if(commandList[i] as DebugCommand<string> != null)
                    {
                        string stringBuild = "";

                        for(int p = 1; p<inputValues.Length; p++)
                        {
                            stringBuild += inputValues[p];
                        }

                        if (stringBuild == "")
                        {
                            NewOutput((commandList[i] as DebugCommand<string>).commandFormat);
                        }
                        else
                        {
                            (commandList[i] as DebugCommand<string>).Invoke(stringBuild);
                        }
                    }
                    else if (commandList[i] as DebugCommand<int> != null)
                    {
                        (commandList[i] as DebugCommand<int>).Invoke(int.Parse(inputValues[1]));
                    }
                    commandFound = true;
                }
            }

            if (!commandFound)
            {
                output.Add("COMMAND: '" + inputValues[0] + "' DOES NOT EXIST");
            }
        }
    }
}
