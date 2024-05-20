using New_MVC.Handlers;
using New_MVC.Models;
using System.Net;
using System.Web.Mvc;

namespace New_MVC.Controllers
{
	public class StudentController : Controller
	{
		private readonly StudentHandler _handler = new StudentHandler();

		// GET: Student
		public ActionResult Index()
		{
			var students = StudentHandler.GetStudents();
			return View(students);
		}

		// GET: Student/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			StudentsData student = _handler.GetStudentById(id.Value);
			if (student == null)
			{
				return HttpNotFound();
			}
			return View(student);
		}

		// GET: Student/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Student/Create 
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(StudentsDataModel viewModel)
		{
			if (ModelState.IsValid)
			{
				StudentHandler handler = new StudentHandler();
				handler.AddStudent(viewModel);
				return RedirectToAction("Index", "Home");
			}
			return View(viewModel);
		}

		// GET: Student/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			StudentsData student = _handler.GetStudentById(id.Value);
			if (student == null)
			{
				return HttpNotFound();
			}
			return View(student);
		}

		// POST: Student/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(StudentsData student)
		{
			if (ModelState.IsValid)
			{
				_handler.UpdateStudent(student);
				return RedirectToAction("Index");
			}
			return View(student);
		}

		// GET: Student/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			StudentsData student = _handler.GetStudentById(id.Value);
			if (student == null)
			{
				return HttpNotFound();
			}
			return View(student);
		}

		// POST: Student/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_handler.DeleteStudent(id);
			return RedirectToAction("Index");
		}
	}
}