using New_MVC.Models;
using New_MVC.Repositories;
using System;
using System.Collections.Generic;

namespace New_MVC.Handlers
{
	public class StudentHandler
	{
		private readonly StudentRepository _repository;

		public StudentHandler()
		{
			_repository = new StudentRepository();
		}
		public static List<StudentsDataModel> GetStudents()
		{
			var result = new List<StudentsDataModel>();

			try
			{
				using (var myRepo = new StudentRepository())
				{
					result = GetStudentsLoop(myRepo.GetAllStudents());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return result;
		}

		private static List<StudentsDataModel> GetStudentsLoop(List<StudentsData> studentList)
		{
			var result = new List<StudentsDataModel>();

			try
			{
				foreach (var item in studentList)
				{
					result.Add(GetViewStudentsModel(item));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return result;
		}

		private static StudentsDataModel GetViewStudentsModel(StudentsData model)
		{
			var result = new StudentsDataModel();

			try
			{
				result.Id = model.Id;
				result.Name = model.Name;
				result.Age = model.Age;
				result.Dob = model.Dob;
				result.City = model.City;
				result.State = model.State;
				result.IsArchived = model.IsArchived;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return result;
		}

		public void AddStudent(StudentsDataModel viewModel)
		{
			var entity = MapViewModelToEntity(viewModel);
			_repository.AddStudent(entity);
		}

		private StudentsData MapViewModelToEntity(StudentsDataModel viewModel)
		{
			return new StudentsData
			{
				Id = viewModel.Id,
				Name = viewModel.Name,
				Age = viewModel.Age,
				Dob = viewModel.Dob,
				Email = viewModel.Email,
				City = viewModel.City,
				State = viewModel.State,
				IsArchived = viewModel.IsArchived
			};
		}

		public StudentsData GetStudentById(int id)
		{
			return _repository.GetStudentById(id);
		}

		public void UpdateStudent(StudentsData student)
		{
			_repository.UpdateStudent(student);
		}

		public void DeleteStudent(int id)
		{
			_repository.DeleteStudent(id);
		}
	}
}