using New_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace New_MVC.Repositories
{
	public class StudentRepository : IDisposable
	{
		private readonly StudentsDbEntities _entities;

		public StudentRepository()
		{
			_entities = new StudentsDbEntities();
		}

		public List<StudentsData> GetAllStudents()
		{
			return _entities.StudentsDatas.ToList();
		}

		public StudentsData GetStudentById(int id)
		{
			return _entities.StudentsDatas.Find(id);
		}

		public void AddStudent(StudentsData student)
		{
			_entities.StudentsDatas.Add(student);
			_entities.SaveChanges();
		}

		public void UpdateStudent(StudentsData student)
		{
			_entities.Entry(student).State = EntityState.Modified;
			_entities.SaveChanges();
		}

		public void DeleteStudent(int id)
		{
			var student = _entities.StudentsDatas.Find(id);
			_entities.StudentsDatas.Remove(student);
			_entities.SaveChanges();
		}

		#region DML

		public object Add<T>(T newItem) where T : class
		{
			var modelObject = _entities.Set<T>().Add(newItem);
			Save();
			return modelObject;
		}

		public object Update<T>(T updateItem) where T : class
		{
			_entities.Entry(updateItem).State = EntityState.Modified;
			Save();
			return updateItem;
		}

		#endregion

		#region Persistence

		public void Save()
		{
			_entities.SaveChanges();
		}

		#endregion

		#region Disposal

		private bool _disposed;

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_entities.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
