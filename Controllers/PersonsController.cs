using FormApplication.Models;
using FormApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormApplication.Controllers
{
    public class PersonsController : Controller
    {
        private readonly ApplicationDatabaseContext context;
        public PersonsController(ApplicationDatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewPerson()
        {
            var products = context.Persons.ToList();
            return View(products);
        }
        [HttpPost]
        public IActionResult AddData(PersonDto personDto)

        {
            if (personDto == null)
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            if (!ModelState.IsValid)
            {
                return View("Index", personDto);
            }
            Person person = new Person { Name = personDto.Name, Company = personDto.Company, Email = personDto.Email, Phone = personDto.Phone, MoreDetails = personDto.MoreDetails, ReasonForContact = personDto.ReasonForContact };
            context.Persons.Add(person);
            context.SaveChanges();
            return RedirectToAction("Index", "Persons");
        }



        public IActionResult Edit(int id)
        {
            Person? person = context.Persons.Where(x => x.Id == id).FirstOrDefault();

            PersonDto personDto = new()
            {
                Id = person.Id,
                Name = person.Name,
                Company = person.Company,
                Email = person.Email,
                Phone = person.Phone,
                MoreDetails = person.MoreDetails,
                ReasonForContact = person.ReasonForContact
            };
            if (person == null)
            {
                return RedirectToAction("ViewPerson", "Persons");
            }
            ViewData["PersonId"] = id;

            return View(personDto);
        }
        public IActionResult UpdateDatabase(PersonDto personDto)
        {


            Person? person = context.Persons.Where(x => x.Id == personDto.Id).FirstOrDefault();
            if (person == null)
            {
                return RedirectToAction("ViewPerson", "Persons");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", personDto);
                }
                else
                {

                    person.Id = personDto.Id;
                    person.Name = personDto.Name;
                    person.Company = personDto.Company;
                    person.Email = personDto.Email;
                    person.Phone = personDto.Phone;
                    person.MoreDetails = personDto.MoreDetails;
                    person.ReasonForContact = personDto.ReasonForContact;
                    context.SaveChanges();
                    return RedirectToAction("ViewPerson", "Persons");
                }


            }


        }
        public IActionResult Success()
        {

            return View();
        }
        public IActionResult Delete(int Id)
        {
            Person? person = context.Persons.Where(x => x.Id == Id).FirstOrDefault();
            if (person == null)
            {
                return RedirectToAction("ViewPerson", "Persons");
            }
            context.Persons.Remove(person);
            context.SaveChanges(true);
            return RedirectToAction("ViewPerson", "Persons");
        }

    }
}
