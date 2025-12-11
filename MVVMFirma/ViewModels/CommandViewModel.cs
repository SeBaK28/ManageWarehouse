using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class CommandViewModel : BaseViewModel
    {
        #region Properties
        public ICommand Command { get; private set; }
        public string Icon { get; set; }
        #endregion

        #region Constructor
        public CommandViewModel(string icon ,string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            this.Icon = icon;
            this.DisplayName = displayName;
            this.Command = command;
        }
        #endregion

    }
}
