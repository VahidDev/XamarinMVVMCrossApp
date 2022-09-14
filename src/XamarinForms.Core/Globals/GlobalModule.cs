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
        private int _counter;

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


        public GlobalModule()
        {
            SetBackgroundTimer();
        }

        private Task SetBackgroundTimer()
        {
            return Task.Run(() =>
            {
                var myTimer = new Timer();
                myTimer.Elapsed += new ElapsedEventHandler(IncrementCounterEvent);
                myTimer.Interval = 2000;
                myTimer.Start();
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
