using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trainings.Models.Request;
using Trainings.Models.Response;
using Trainings.Services.Abstracts;

namespace Trainings.Controllers
{
    [Authorize(Roles = WebConstants.AdminRole)]
    public class TrainingController : Controller
    {
        private readonly ITrainingService trainingService;
        private readonly ITechnologyService technologyService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TrainingController(ITrainingService trainingService, ITechnologyService technologyService, IWebHostEnvironment webHostEnvironment)
        {
            this.trainingService = trainingService;
            this.technologyService = technologyService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var trainings = await trainingService.GetTrainings();

            return View(trainings);
        }

        public async Task<IActionResult> Upsert(Guid? id)
        {
            var technologies = await technologyService.GetTechnologies();

            var trainingModel = new TrainingRequestModel()
            {
                TechnologySelectList = technologies.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString(),
                }),
            };

            if (id is null)
            {
                return View(trainingModel);
            }
            else
            {
                var oldTrainingModel = await trainingService.FindTrainingById(id);
                if (oldTrainingModel is null)
                {
                    return NotFound();
                }
                else
                {
                    oldTrainingModel.TechnologySelectList = trainingModel.TechnologySelectList;
                    return View(oldTrainingModel);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(TrainingRequestModel trainingModel)
        {
            var files = HttpContext.Request.Form.Files;
            var webRootPath = webHostEnvironment.WebRootPath;

            var upload = webRootPath + WebConstants.ImagePath;
            var fileName = Guid.NewGuid().ToString();
            var extention = Path.GetExtension(files[0].FileName);
            var fullName = fileName + extention;

            if (trainingModel.Id is null)
            {
                using var fileStream = new FileStream(Path.Combine(upload, fullName), FileMode.Create);
                files[0].CopyTo(fileStream);

                trainingModel.Image = fullName;

                await trainingService.AddTraining(trainingModel);
            }
            else
            {
                var oldTraining = await trainingService.FindTrainingByIdNoTracking(trainingModel.Id);

                if (files.Count() > 0)
                {
                    var oldFile = Path.Combine(upload, oldTraining.Image);

                    if (System.IO.File.Exists(oldFile))
                    {
                        System.IO.File.Delete(oldFile);
                    }

                    using var fileStream = new FileStream(Path.Combine(upload, fullName), FileMode.Create);
                    files[0].CopyTo(fileStream);

                    trainingModel.Image = fullName;
                }
                else
                {
                    trainingModel.Image = oldTraining.Image;
                }

                await trainingService.UpdateTraining(trainingModel);
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = WebConstants.StudentRole)]
        public async Task<IActionResult> Register(Guid trainingId)
        {
            Console.WriteLine(trainingId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(TrainingModel trainingModel)
        {
            return RedirectToAction("Index");
        }
    }
}
