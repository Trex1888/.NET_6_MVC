namespace New_MVC.Models
{
	public class StudentsDataModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public System.DateTime Dob { get; set; }
		public string Email { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public bool IsArchived { get; set; }
	}
}