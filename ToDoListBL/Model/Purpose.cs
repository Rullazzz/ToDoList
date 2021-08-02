using System;

namespace ToDoListBL
{
	[Serializable]
	public class Purpose
	{
		public string TaskToComplete { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime Deadline { get; set; }

		public Purpose(string taskToComplete, DateTime deadline)
		{
			TaskToComplete = taskToComplete ?? throw new ArgumentNullException(nameof(taskToComplete));
			DateCreation = DateTime.Now;
			Deadline = deadline;
		}

		public override string ToString()
		{
			return TaskToComplete + " " + DateCreation;
		}
	}
}
