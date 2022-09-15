using System;
using System.Runtime.CompilerServices;

namespace XamarinForms.Core.Globals
{
    public interface IGlobalModule
    {
        int Counter { get; set; }

        event Action GlobalCounterChangedEvent;

        void OnPropertyChanged([CallerMemberName] string propetyName = null);

        /// <summary>
        /// Start thread safe backrgound timer
        /// </summary>
        void StartBackgroundTimer();
    }
}
