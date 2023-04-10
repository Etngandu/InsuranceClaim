using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.InsuranceAndClaims.Entities.Repositories;
using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.Infrastructure;
using ENB.InsuranceAndClaims.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using ENB.InsuranceAndClaims.EF.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;

namespace ENB.InsuranceAndClaims.MVC.Controllers
{
    public class ClaimProcessingStageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClaimProcessingStageController> _logger;
        private readonly IAsyncClaimProcessingStageRepository _asyncClaimProcessingStageRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly INotyfService _notyf;
        public ClaimProcessingStageController(IMapper mapper, ILogger<ClaimProcessingStageController> logger,
                                   IAsyncClaimProcessingStageRepository asyncClaimProcessingStageRepository,
                                   IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                   INotyfService notyf)
        {
            _mapper = mapper;
            _logger = logger;
            _asyncClaimProcessingStageRepository = asyncClaimProcessingStageRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _notyf = notyf;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetClaimProcessingStageData()
        {
            IQueryable<ClaimProcessingStage> allClaimProcessingStage = _asyncClaimProcessingStageRepository.FindAll();

            var Mpdata = _mapper.Map<List<DisplayClaimProcessingStage>>(allClaimProcessingStage).ToList();
            await Task.FromResult(Mpdata);
            return Json(new { data = Mpdata });
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Id = id;

            _logger.LogError($"Id :{id} of Customer not found");

            ClaimProcessingStage dbClaimProcessingStage = await _asyncClaimProcessingStageRepository.FindById(id);

            ViewBag.Message = dbClaimProcessingStage.Claim_Status_Name;

            _logger.LogInformation($"Details of Staff: {ViewBag.Message}");

            if (dbClaimProcessingStage is null)
            {
                return NotFound();
            }

            var data = _mapper.Map<DisplayClaimProcessingStage>(dbClaimProcessingStage);

            return View(data);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditClaimProcessingStage createAndEditClaimProcessingStage)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        ClaimProcessingStage dbClaimProcessingStage = new();

                        _mapper.Map(createAndEditClaimProcessingStage, dbClaimProcessingStage);
                        await _asyncClaimProcessingStageRepository.Add(dbClaimProcessingStage);

                        _notyf.Success("ClaimProcessingStage Created  Successfully! ");

                        return RedirectToAction("Index");
                    }
                }
                catch (ModelValidationException mvex)
                {
                    foreach (var error in mvex.ValidationErrors)
                    {
                        ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage!);
                    }
                }
            }
            return View();
        }

        // GET: CustomerController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {



            ClaimProcessingStage dbClaimProcessingStage = await _asyncClaimProcessingStageRepository.FindById(id);

            if (dbClaimProcessingStage is null)
            {
                _logger.LogError($"Staff {id} not found");
                return NotFound();
            }

            var data = new CreateAndEditClaimProcessingStage()
            {

                ListStages = _asyncClaimProcessingStageRepository.FindAll()
                 .Select(d => new SelectListItem 
                 {
                     Text = d.Claim_Status_Name,
                     Value = d.Id.ToString(),
                     Selected = true

                 }).Distinct().ToList()

            };
            
            _mapper.Map(dbClaimProcessingStage,data);

            return View(data);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditClaimProcessingStage createAndEditClaimProcessingStage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        ClaimProcessingStage dbClaimProcessingStage = await _asyncClaimProcessingStageRepository.FindById(createAndEditClaimProcessingStage.Id);

                        _mapper.Map(createAndEditClaimProcessingStage, dbClaimProcessingStage, typeof(CreateAndEditClaimProcessingStage), typeof(ClaimProcessingStage));

                        _notyf.Success("ClaimProcessingStage Updated  Successfully! ");

                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (ModelValidationException mvex)
                {
                    foreach (var error in mvex.ValidationErrors)
                    {
                        ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage!);
                    }
                }
            }

            createAndEditClaimProcessingStage.ListStages = _asyncClaimProcessingStageRepository.FindAll()
                  .Select(d => new SelectListItem
                  {
                      Text = d.Claim_Status_Name,
                      Value = d.Id.ToString(),
                      Selected = true

                  }).Distinct().ToList();
            return View("Edit",createAndEditClaimProcessingStage);
        }

        // GET: CustomerController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ClaimProcessingStage dbClaimProcessingStage = await _asyncClaimProcessingStageRepository.FindById(id);
            ViewBag.Message = dbClaimProcessingStage.Claim_Status_Name;

            if (dbClaimProcessingStage is null)
            {
                return NotFound();
            }
            var data = _mapper.Map<DisplayClaimProcessingStage>(dbClaimProcessingStage);
            return View(data);
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ClaimProcessingStage dbClaimProcessingStage = await _asyncClaimProcessingStageRepository.FindById(id);
            await using (await _asyncUnitOfWorkFactory.Create())
            {
                _asyncClaimProcessingStageRepository.Remove(dbClaimProcessingStage);

                _notyf.Error("ClaimProcessingStage Removed  Successfully! ");
            }

            return RedirectToAction(nameof(Index)); ;
        }
    }
}
