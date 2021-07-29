using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBL
{
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
