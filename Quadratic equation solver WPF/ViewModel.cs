using EquationSolver;
using EquationSolverTuple;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Quadratic_equation_solver_WPF
{
	class ViewModel : INotifyPropertyChanged
	{

        #region Fields
        /// <summary>
        /// Creates instance of the EquationSolver
        /// </summary>
        Solver solve = new Solver();
        SolverTuple solveTuple = new SolverTuple();

        /// <summary>
		/// The time command
		/// </summary>
		private DateTime timeCommand;

        /// <summary>
		/// The update text box
		/// </summary>
		private string updateTextBox;

        /// <summary>
		/// The update label
		/// </summary>
		private string updateLabel;

        /// <summary>
        /// The index History
        /// </summary>
        int indexHistory = 1;

        #endregion

        #region Properties

		/// <summary>
		/// Gets or sets the time command.
		/// </summary>
		/// <value>
		/// The time command.
		/// </value>
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

		/// <summary>
		/// Gets or sets the update text box.
		/// </summary>
		/// <value>
		/// The update text box.
		/// </value>
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

		/// <summary>
		/// Gets or sets the update label.
		/// </summary>
		/// <value>
		/// The update label.
		/// </value>
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

		#endregion

        #region Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        /// <summary>
        /// Handles the Tick event of the dispatcherTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            TimeCommand = DateTime.Now;

        } 
        #endregion

        #region PropertyChanged
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
        #endregion

		#region Commands

        /// <summary>
        /// Updates the label execute.
        /// </summary>
		void UpdateLabelExecute()
		{

			//UpdateLabel = solve.Results(UpdateTextBox);

            var tupleResults = solveTuple.ResultsTuple(UpdateTextBox);
            UpdateLabel = tupleResults.Item1;
            
            listViewCollection.Add(new ListViewData { ListView_No = indexHistory.ToString(),
                                                      ListView_a = solveTuple.a.ToString(),
                                                      ListView_b = solveTuple.b.ToString(),
                                                      ListView_c = solveTuple.c.ToString(),
                                                      ListView_Discriminant = solveTuple.Discriminant.ToString(),
                                                      ListView_x1 = tupleResults.Item2,
                                                      ListView_x2 = tupleResults.Item3
                                                    });

            indexHistory++;


		}


        #region ExitApplicationClick
        /// <summary>
        /// Determines whether this instance [can update label execute].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can update label execute]; otherwise, <c>false</c>.
        /// </returns>
		bool CanUpdateLabelExecute()
		{
			if (!string.IsNullOrWhiteSpace(UpdateTextBox))  //disables the Calculate button or Solve menu item when UpdateTextBox is empty
			{
				return true;
			}
			else 
			{
				return false;
			}
			
		}

        /// <summary>
        /// Gets the update label button click.
        /// </summary>
        /// <value>
        /// The update label button click.
        /// </value>
		public ICommand UpdateLabelButtonClick
		{
			get { return new RelayCommand(UpdateLabelExecute, CanUpdateLabelExecute); }
		}

        #region ExitApplicationClick
        /// <summary>
        /// Exits the application command.
        /// </summary>
		void ExitApplicationCommand()
		{
			Application.Current.Shutdown();
		}

        /// <summary>
        /// Determines whether this instance [can exit application execute].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can exit application execute]; otherwise, <c>false</c>.
        /// </returns>
		bool CanExitApplicationExecute()
		{
			return true;
		}

        /// <summary>
        /// Gets the exit application click.
        /// </summary>
        /// <value>
        /// The exit application click.
        /// </value>
		public ICommand ExitApplicationClick  //bind to "ExitApplicationClick" name in XAML
		{
			get { return new RelayCommand(ExitApplicationCommand, CanExitApplicationExecute); }
		}

        #endregion
        #endregion
       
        /// <summary>
        /// ///////////////////////WriteHistoryToFileClick
        /// </summary>
        /// 

        void WriteHistoryToFileClickCommand()
        {
            using (var writer = new StreamWriter(@"i:\test.txt"))
            {
                writer.WriteLine("No. \t a \t b \t c \t Discriminant \t Root1 \t Root2");
                foreach (ListViewData item in ListViewCollection)
                {
                    writer.WriteLine(item.ListView_No + " \t" + item.ListView_a + " \t" + item.ListView_b + " \t" + item.ListView_c
                                     + " \t" + item.ListView_Discriminant + " \t" + item.ListView_x1 
                                     + " \t" + item.ListView_x2);
                }
            }
        }

      
        bool CanWriteHistoryToFileClickExecute()
        {
            return true;
        }

        
        public ICommand WriteHistoryToFileClick
        {
            get { return new RelayCommand(WriteHistoryToFileClickCommand, CanWriteHistoryToFileClickExecute); }
        }

        #endregion

        ObservableCollection<ListViewData> listViewCollection = new ObservableCollection<ListViewData>();

        public ObservableCollection<ListViewData> ListViewCollection
        { get { return listViewCollection; } }

       
    }

    public class ListViewData
    {
        public string ListView_No { get; set; }
        public string ListView_a { get; set; }
        public string ListView_b { get; set; }
        public string ListView_c { get; set; }
        public string ListView_Discriminant { get; set; }
        public string ListView_x1 { get; set; }
        public string ListView_x2 { get; set; }

    }
}


