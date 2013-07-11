using EquationSolver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Quadratic_equation_solver_WPF
{
    class ViewModel : INotifyPropertyChanged
    {
        
        Solver solve = new Solver();
        private DateTime _now;

        public ViewModel()
	    {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
	    }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
                TimeCommand = DateTime.Now;
              
        }

        private string updateTextBox;

        public string UpdateTextBox
        {
            get { return updateTextBox; }
            set
            {
                if (updateTextBox != value)
                {
                    updateTextBox = value;
                    RaisePropertyChanged("UpdateTextBox");      
                }                                              
                updateTextBox = value;                          
            }                                                    
        }

        private string updateLabel;

        public string UpdateLabel
        {
            get { return updateLabel; }
            set
            {
                if (updateLabel != value)
                {
                    updateLabel = value;
                    RaisePropertyChanged("UpdateLabel");
                }
                updateLabel = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Commands
        void UpdateLabelExecute()
        {

            UpdateLabel = solve.Results(UpdateTextBox);
        }

        bool CanUpdateLabelExecute()
        {
            return true;
        }

        public ICommand UpdateLabelButtonClick
        {
            get { return new RelayCommand(UpdateLabelExecute, CanUpdateLabelExecute); }
        }
        #endregion


        ///////////////////////////////////////DateTime
        #region DateTime



        private DateTime timeCommand;

        public DateTime TimeCommand
        {
            get { return timeCommand; }
            set
            {
                if (timeCommand != value)
                {
                    timeCommand = value;
                    RaisePropertyChanged("TimeCommand");
                }
                timeCommand = value;
            }
        }
        #endregion

    }
}
