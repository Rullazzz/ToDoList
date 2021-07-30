using System;

namespace ToDoListBL
{
	[Serializable]
	public class Purpose
	{
		public string TaskToComplete { get; set; }
		public DateTime DateCreation { get; set; }

		public Purpose(string taskToComplete, DateTime dateCreation)
		{
			TaskToComplete = taskToComplete ?? throw new ArgumentNullException(nameof(taskToComplete));
			DateCreation = dateCreation;
		}

		public override string ToString()
		{
			return TaskToComplete + " " + DateCreation;
		}
	}
}
