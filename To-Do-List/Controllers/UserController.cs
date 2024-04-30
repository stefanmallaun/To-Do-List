using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using To_Do_List.DB;
using To_Do_List.Models;

namespace To_Do_List.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult OneElement()
        {
            To_do_Element a = new To_do_Element();
            a.Id = 1;
            a.Title = "Test";
            a.Description = "Test";
            a.Type = Type_of_Element.work;

            return View(a);
        }

        public IActionResult Overview()
        {
            List<To_do_Element> a = new List<To_do_Element>();

            To_do_Element a1 = new To_do_Element()
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Type = Type_of_Element.work
            };
            a.Add(a1);
            To_do_Element a2 = new To_do_Element()
            {
                Id = 2,
                Title = "Test2",
                Description = "Test2",
                Type = Type_of_Element.work
            };
            a.Add(a2);
            To_do_Element a3 = new To_do_Element()
            {
                Id = 3,
                Title = "Test2",
                Description = "Test2",
                Type = Type_of_Element.work
            };
            a.Add(a3);
            To_do_Element a4 = new To_do_Element()
            {
                Id = 4,
                Title = "Test2",
                Description = "Test2",
                Type = Type_of_Element.work
            };
            a.Add(a4);


            return View(a);

        }


        public async Task<IActionResult> InputToDo(To_do_Element Todo)
        {
            if (Todo.Id == null)
            {
                ModelState.AddModelError("Error", "Darf nicht null sein");
            }

            if (ModelState.IsValid)
            {
                using (var dbManager = new DbManager())
                {
                    dbManager.ToDoElement.Add(Todo);
                    await saveToDbAsync(dbManager);
                }
            }
            else
            {
                return View();
            }
            return View();

        }
        public static async Task saveToDbAsync(DbManager d)
        {
            try
            {
                await d.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                await Console.Out.WriteLineAsync("DB-Update Error");
            }
        }


        public async Task<IActionResult> showAllTasks()
        {
            using (var dbManager = new DbManager())
            {
                List<To_do_Element> a = await dbManager.ToDoElement.ToListAsync<To_do_Element>();
                return View(a);

            }



        }

    }
}
