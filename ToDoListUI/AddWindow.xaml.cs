using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoListBL;

namespace ToDoListUI
{
	/// <summary>
	/// Логика взаимодействия для AddWindow.xaml
	/// </summary>
	public partial class AddWindow : Window
	{
		public Purpose Purpose { get; set; }
		public AddWindow()
		{
			InitializeComponent();
		}

		private void AddButtom_Click(object sender, RoutedEventArgs e)
		{
			var taskToComplete = TaskToCompleteTextBox.Text;
			// TODO: Придумать другое решение при DeadlineDatePicker == null.
			var deadline = DeadlineDatePicker.SelectedDate ?? DateTime.Now;
			Purpose = new Purpose(taskToComplete, deadline);
			Close();
		}
	}
}
