using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.InsuranceAndClaims.Entities.Repositories;
using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.Infrastructure;
using ENB.InsuranceAndClaims.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ENB.InsuranceAndClaims.MVC.Controllers
{
    public class PolicyTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PolicyTypeController> _logger;
        private readonly IAsyncPolicyTypeRepository _asyncPolicyTypeRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly INotyfService _notyf;
        public PolicyTypeController(IMapper mapper, ILogger<PolicyTypeController> logger,
                                   IAsyncPolicyTypeRepository asyncPolicyTypeRepository,
                                   IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                   INotyfService notyf)
        {
            _mapper = mapper;
            _logger = logger;
            _asyncPolicyTypeRepository = asyncPolicyTypeRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _notyf = notyf;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPolicyTypeData()
        {
            IQueryable<PolicyType> allPolicyTypes = _asyncPolicyTypeRepository.FindAll();

            var Mpdata = _mapper.Map<List<DisplayPolicyType>>(allPolicyTypes).ToList();
            await Task.FromResult(Mpdata);
            return Json(new { data = Mpdata });
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Id = id;

            _logger.LogError($"Id :{id} of Customer not found");

           PolicyType dbPolicyType = await _asyncPolicyTypeRepository.FindById(id);

            ViewBag.Message = dbPolicyType.PolicyTypeCode;

            _logger.LogInformation($"Details of PolicyType: {ViewBag.Message}");

            if (dbPolicyType is null)
            {
                return NotFound();
            }

            var data = _mapper.Map<DisplayPolicyType>(dbPolicyType);

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
        public async Task<IActionResult> Create(CreateAndEditPolicyType createAndEditPolicyType)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                       PolicyType NewPolicyType = new();

                        _mapper.Map(createAndEditPolicyType, NewPolicyType);
                        await _asyncPolicyTypeRepository.Add(NewPolicyType);

                        _notyf.Success("PolicyType Created  Successfully! ");

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



           PolicyType dbPolicyType = await _asyncPolicyTypeRepository.FindById(id);

            if (dbPolicyType is null)
            {
                _logger.LogError($"Staff {id} not found");
                return NotFound();
            }
            var data = await Task.FromResult(_mapper.Map<CreateAndEditPolicyType>(dbPolicyType));

            return View(data);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditPolicyType createAndEditPolicyType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                       PolicyType dbPolicyTypeToUpdate = await _asyncPolicyTypeRepository.FindById(createAndEditPolicyType.Id);

                        _mapper.Map(createAndEditPolicyType, dbPolicyTypeToUpdate, typeof(CreateAndEditPolicyType), typeof(PolicyType));

                        _notyf.Success("PolicyType Updated  Successfully! ");

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
            return View();
        }

        // GET: CustomerController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           PolicyType dbPolicyType = await _asyncPolicyTypeRepository.FindById(id);
            ViewBag.Message = dbPolicyType.PolicyTypeCode;

            if (dbPolicyType is null)
            {
                return NotFound();
            }
            var data = _mapper.Map<DisplayPolicyType>(dbPolicyType);
            return View(data);
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           PolicyType dbPolicyType = await _asyncPolicyTypeRepository.FindById(id);
            await using (await _asyncUnitOfWorkFactory.Create())
            {
                _asyncPolicyTypeRepository.Remove(dbPolicyType);

                _notyf.Error("PolicyType Removed  Successfully! ");
            }

            return RedirectToAction(nameof(Index)); ;
        }
    }
}
