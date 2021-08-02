using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoListBL
{
	[Serializable]
	public class Purpose : INotifyPropertyChanged
	{
		private string _taskToComplete;
		public string TaskToComplete
		{
			get { return _taskToComplete; }
			set
			{
				_taskToComplete = value;
				OnPropertyChanged();
			}
		}

		private DateTime _dateCreation;
		public DateTime DateCreation
		{
			get { return _dateCreation; }
			set
			{
				_dateCreation = value;
				OnPropertyChanged();
			}
		}

		private DateTime _deadline;
		public DateTime Deadline
		{
			get { return _deadline; }
			set
			{
				_deadline = value;
				OnPropertyChanged();
			}
		}

		public Purpose(string taskToComplete, DateTime deadline)
		{
			TaskToComplete = taskToComplete ?? throw new ArgumentNullException(nameof(taskToComplete));
			DateCreation = DateTime.Now;
			Deadline = deadline;
		}

		[field: NonSerializedAttribute()]
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		public override string ToString()
		{
			return TaskToComplete + " " + DateCreation;
		}
	}
}
