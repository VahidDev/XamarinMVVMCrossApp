using System.Runtime.CompilerServices;

namespace XamarinForms.Core.Globals
{
    public interface IGlobalModule
    {
        int Counter { get; set; }

        void OnPropertyChanged([CallerMemberName] string propetyName = null);

        /// <summary>
        /// Start thread safe backrgound timer
        /// </summary>
        void StartBackgroundTimer();
    }
}
