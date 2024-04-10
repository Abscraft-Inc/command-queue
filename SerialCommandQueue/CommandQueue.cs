using System;
using System.Runtime.CompilerServices;
using Crestron.SimplSharp;

namespace SerialCommandQueue
{
    public class CommandQueue
    {
        private CrestronQueue<string> _queue;
        private CTimer _timer;
        private bool _isBusy;
        private string _currentCommand;
        
        private ushort _timerInterval;
        public ushort TimerInterval
        {
            get { return _timerInterval; }
            set { _timerInterval = value; }
        }
        
        public event EventHandler<CommandArgs> CommandSent = delegate(object sender, CommandArgs args) {  };
        private void OnCommandSent(string command)
        {
            var handler = CommandSent;
            if (handler != null)
            {
                handler(this, new CommandArgs { Command = command });
            }
        }
        
        public CommandQueue()
        {
            _queue = new CrestronQueue<string>();
            _timer = new CTimer(Start, null, 0, Timeout.Infinite);
            _isBusy = false;
            _currentCommand = string.Empty;
        }

        public void AddCommand(string command)
        {
            _queue.Enqueue(command);
        }
        
        public void Start(object o)
        {
            //while (true)
            //{
                if (!_isBusy && _queue.Count > 0)
                {
                    _currentCommand = _queue.Dequeue();
                    _isBusy = true;
                    SendCommand(_currentCommand);
                    _timer.Reset(_timerInterval);
                }
                else
                    _timer.Reset(1000);
            //}
        }
        
        private void SendCommand(string command)
        {
            //CrestronConsole.PrintLine("Sending command: {0}", command);
            OnCommandSent(command);
            //CrestronEnvironment.Sleep(1000);
            _isBusy = false;
        }
    }
    
    public class CommandArgs : EventArgs
    {
        public string Command { get; set; }
    }
}