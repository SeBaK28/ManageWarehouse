using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class MenuItemViewModel: BaseViewModel
    {
        #region Properties
        public ICommand Command { get; private set; }
        #endregion

        #region Constructor
        public MenuItemViewModel( string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("menuitem");
            this.DisplayName = displayName;
            this.Command = command;
        }
        #endregion
    }
}
