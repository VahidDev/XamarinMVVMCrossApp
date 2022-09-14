using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinForms.Core.Globals
{
    public interface IGlobalModule
    {
        int Counter { get; set; }
        void OnPropertyChanged([CallerMemberName] string propetyName = null);
    }
}
