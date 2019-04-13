using EventRegistration.Models;
using EventRegistration.Services;
using EventRegistration.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EventRegistration.Controllers
{
    public class EventController : Controller
    {
        private readonly IRepository<Registration> _registrationRepository;
        private readonly IRepository<Day> _eventDayRepository;
        private readonly IRepository<Gender> _genderRepository;

        public EventController(IRepository<Registration> registrationRepository, IRepository<Day> eventDayRepository, IRepository<Gender> genderRepository)
        {
            _registrationRepository = registrationRepository;
            _eventDayRepository = eventDayRepository;
            _genderRepository = genderRepository;
        }

        public IActionResult Index()
        {
            return View(_registrationRepository.GetAll());
        }

        public IActionResult Add()
        {
            if (TempData["AddError"] != null)
            {
                ModelState.AddModelError("Error", TempData["AddError"].ToString());
            }
            var eventAddViewModel = new AddEventViewModel
            {
                EventDays = _eventDayRepository.GetAll().Select(s => new ChecklistItem { Id = s.Id, Label = s.Label }).ToList(),
                Genders = _genderRepository.GetAll().Select(s => new ChecklistItem { Id = s.Id, Label = s.Label, Value = s.Value }).ToList()
            };
            return View(eventAddViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (addEventViewModel.EventDays.Where(w => w.Selected)?.Count() <= 0)
            {
                TempData["AddError"] = "SelectedDays is required";
                return RedirectToAction("Add", addEventViewModel);
            }
            if (!ModelState.IsValid) return RedirectToAction("Add", addEventViewModel);
            addEventViewModel.Registration.SelectedDays = addEventViewModel.EventDays
                .Where(w => w.Selected).Select(s => new Day { Id = s.Id, Label = s.Label }).ToList();
            _registrationRepository.Add(addEventViewModel.Registration);

            return RedirectToAction("Index");
        }
    }
}