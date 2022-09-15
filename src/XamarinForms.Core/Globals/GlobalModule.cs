using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;

namespace XamarinForms.Core.Globals
{
    public class GlobalModule
        : INotifyPropertyChanged
        , IGlobalModule
    {
        private static object _lock = new object();
        private bool _timerStarted;
        private int _counter;
        private Timer _timer;

        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void StartBackgroundTimer()
        {
            if (!_timerStarted)
            {
                lock (_lock)
                {
                    if (!_timerStarted)
                    {
                        InitializeTimer();
                        _timerStarted = true;
                    }
                }
            }
        }

        private Task InitializeTimer()
        {
            return Task.Run(() =>
            {
                _timer = new Timer();
                _timer.Elapsed += new ElapsedEventHandler(IncrementCounterEvent);
                _timer.Interval = 2000;
                _timer.Start();
            });
        }

        public void IncrementCounterEvent(object source, ElapsedEventArgs e)
        {
            IncrementCounter();
        }

        private void IncrementCounter() => Counter++;

        public void OnPropertyChanged([CallerMemberName] string propetyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
    }
}
