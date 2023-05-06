namespace MyApplicationName.Models.Models
{
	public class TimeModel
	{
		public int Hours { get; set; }
		public int Minutes { get; set; }

		public bool CheckForSameTime(DateTime time)
		{
			return time.Hour == Hours && time.Minute == Minutes;
		}
	}
}