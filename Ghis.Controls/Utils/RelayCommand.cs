// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace Ghis.Controls.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RelayCommand : System.Windows.Input.ICommand
{
    #region Properties

    private readonly Action<object>? ExecuteAction;
    private readonly Predicate<object> CanExecuteAction;

    #endregion

    public RelayCommand(Action<object> execute) : this(execute, _ => true)
    {
    }

    public RelayCommand(Action<object> action, Predicate<object> canExecute)
    {
        ExecuteAction = action;
        CanExecuteAction = canExecute;
    }

    #region Methods

    public bool CanExecute(object parameter)
    {
        return this.CanExecuteAction.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged
    {
        add { System.Windows.Input.CommandManager.RequerySuggested += value; }
        remove { System.Windows.Input.CommandManager.RequerySuggested -= value; }
    }

    public void Execute(object parameter)
    {
        this.ExecuteAction(parameter);
    }

    #endregion
}