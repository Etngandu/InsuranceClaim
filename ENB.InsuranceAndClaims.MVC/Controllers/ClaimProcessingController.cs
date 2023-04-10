using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.InsuranceAndClaims.Entities.Repositories;
using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.Infrastructure;
using ENB.InsuranceAndClaims.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using ENB.InsuranceAndClaims.Entities.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ENB.InsuranceAndClaims.MVC.Controllers
{
    public class ClaimProcessingController : Controller
    {
        private readonly IAsyncCustomerRepository _asyncCustomerRepository;
        private readonly IAsyncStaffRepository _asyncStaffRepository;
        private readonly IAsyncPolicyTypeRepository _asyncPolicyTypeRepository;
        private readonly IAsyncClaimProcessingStageRepository _asyncClaimProcessingStageRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<ClaimProcessingController> _logger;
        private readonly IMapper _imapper;
        private readonly INotyfService _notyf;
        public ClaimProcessingController(IAsyncCustomerRepository asyncCustomerRepository,
                                       IAsyncStaffRepository asyncStaffRepository,
                                      IAsyncPolicyTypeRepository asyncPolicyTypeRepository,
                                      IAsyncClaimProcessingStageRepository asyncClaimProcessingStageRepository,
                                      IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                      ILogger<ClaimProcessingController> logger,
                                     IMapper imapper,
                                     INotyfService notyf)
        {
            _asyncCustomerRepository = asyncCustomerRepository;
            _asyncStaffRepository = asyncStaffRepository;
            _asyncPolicyTypeRepository = asyncPolicyTypeRepository;
            _asyncClaimProcessingStageRepository = asyncClaimProcessingStageRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _logger = logger;
            _imapper = imapper;
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List(int CustomerId, int PolicyId, int ClaimHeaderId)
        {
            ViewBag.Idcust = CustomerId;
            ViewBag.Idpol = PolicyId;
            ViewBag.Idclh = ClaimHeaderId;

            var customer = await _asyncCustomerRepository.FindById(CustomerId, pl => pl.ClaimHeaders);
            var claimheader = customer.ClaimHeaders.Where(x => x.Id == PolicyId)
                         .Where(y => y.Id == ClaimHeaderId);

            ViewBag.Message = customer.FullName;
            //ViewBag.ArtNumber = claimheader.;
            //ViewBag.ClailTypecode = claimheader.Ref_Claim_Type;

            return View();
        }


        public async Task<IActionResult> GetListClaimProcessing(int CustomerId, int PolicyId, int ClaimHeaderId
                                                                )
        {

            var claimproclist = _asyncCustomerRepository.FindAll().Where(cs => cs.Id == CustomerId)
                                         .SelectMany(cp => cp.ClaimProcessings).Where(x => x.PolicyId == PolicyId);

            var claimproc =   from cp  in  claimproclist.Where(y => y.ClaimHeaderId == ClaimHeaderId)                             
                              join cst in _asyncCustomerRepository.FindAll() on cp.CustomerId equals cst.Id
                              join pl in _asyncCustomerRepository.FindAll().Where(cs => cs.Id == CustomerId).SelectMany(y => y.Policies)
                                   on cp.PolicyId equals pl.Id
                              join plt in _asyncPolicyTypeRepository.FindAll() on pl.PolicyTypeId equals plt.Id
                              join ch in _asyncCustomerRepository.FindAll().Where(cs => cs.Id == CustomerId).SelectMany(y => y.ClaimHeaders)
                                    on cp.ClaimHeaderId equals ch.Id
                              join stg in _asyncClaimProcessingStageRepository.FindAll()
                                   on cp.ClaimProcessingStageId equals stg.Id
                              select new DisplayClaimProcessing
                                   {
                                       Id = cp.Id,
                                       Claim_Type = ch.Ref_Claim_Type,
                                       Stage_Outcome=cp.Stage_Outcome,
                                       ClaimStatusName=stg.Claim_Status_Name,
                                       DateCreated = cp.DateCreated,
                                       DateModified = cp.DateModified,
                                       Namecustomer = cst.FullName,
                                       Policycode = plt.PolicyTypeCode,                                      
                                       Other_Details = cp.Other_Details

                                   };




            var lst = await Task.FromResult(claimproc);

          

            return Json(new { data = lst });


        }

        [HttpGet]
        public async Task<IActionResult> Create(int CustomerId, int PolicyId, int ClaimHeaderId)
        {
            ViewBag.Idcust = CustomerId;
            ViewBag.Idpol = PolicyId;
            ViewBag.Idclh = ClaimHeaderId;


            var customer = await _asyncCustomerRepository.FindById(CustomerId, cl => cl.ClaimHeaders);
            var claimHeader = customer.ClaimHeaders.Where(x => x.PolicyId == PolicyId)
                             .Single(y => y.Id == ClaimHeaderId);

            var data = new CreateAndEditClaimProcessing()
            {
               
                ListStaff = _asyncStaffRepository.FindAll()
                      .Select(d => new SelectListItem
                      {
                          Text = d.FullName,
                          Value = d.Id.ToString(),
                          Selected = true

                      }).Distinct().ToList(),
                ListStage = _asyncClaimProcessingStageRepository.FindAll()
                      .Select(d => new SelectListItem
                      {
                          Text = d.Claim_Status_Name,
                          Value = d.Id.ToString(),
                          Selected = true

                      }).Distinct().ToList()

            };


            ViewBag.Message = customer.FullName;
            //ViewBag.ArtNumber = policy.PolicyType;
            //ViewBag.ClailTypecode = claimheader.Ref_Claim_Type;

            return View(data);
        }

        // POST: LawyerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditClaimProcessing
                                                createAndEditClaimProcessing, 
                                               int CustomerId, 
                                               int PolicyId,
                                               int ClaimHeaderId)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimHeaders);

                        var claimheader = customer.ClaimHeaders.Where(x => x.PolicyId == PolicyId)
                                         .Single(y => y.Id == ClaimHeaderId);

                        ClaimProcessing claimProcessing = new();

                        _imapper.Map(createAndEditClaimProcessing, claimProcessing);

                        claimheader.ClaimProcessings.Add(claimProcessing);

                        _notyf.Success("Claim Processing Added  Successfully! ");

                        return RedirectToAction(nameof(List), new { CustomerId, PolicyId, ClaimHeaderId });
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

            createAndEditClaimProcessing.ListStaff = _asyncStaffRepository.FindAll().Select(d => new SelectListItem
            {
                Text = d.FullName,
                Value = d.Id.ToString(),
                Selected = true

            }).Distinct().ToList();

            createAndEditClaimProcessing.ListStage = _asyncClaimProcessingStageRepository.FindAll().Select(d => new SelectListItem
            {
                Text = d.Claim_Status_Name,
                Value = d.Id.ToString(),
                Selected = true

            }).Distinct().ToList();

            ViewBag.Idcust = createAndEditClaimProcessing.CustomerId;
            ViewBag.Idpol = createAndEditClaimProcessing.PolicyId;
            ViewBag.Idclh = createAndEditClaimProcessing.ClaimHeaderId;
            return View("Create",createAndEditClaimProcessing);
        }



        public async Task<IActionResult> Edit(int CustomerId, int PolicyId, int ClaimHeaderId, int id)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimProcessings);
            var claimprocessing = customer.ClaimProcessings.Where(x => x.PolicyId == PolicyId)
                               .Where(y=>y.ClaimHeaderId==ClaimHeaderId)
                               .Single(z => z.Id == id);

            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = CustomerId;
            ViewBag.Id = id;
            ViewBag.Idpol = PolicyId;
            ViewBag.Idclh = ClaimHeaderId;


            if (customer is null)
            {
                return NotFound();
            }

            var data = new CreateAndEditClaimProcessing()
            {

                ListStaff = _asyncStaffRepository.FindAll()
                  .Select(d => new SelectListItem
                  {
                      Text = d.FullName,
                      Value = d.Id.ToString(),
                      Selected = true

                  }).Distinct().ToList(),
                ListStage = _asyncClaimProcessingStageRepository.FindAll()
                  .Select(d => new SelectListItem
                  {
                      Text = d.Claim_Status_Name,
                      Value = d.Id.ToString(),
                      Selected = true

                  }).Distinct().ToList()

            };



            _imapper.Map(claimprocessing, data);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditClaimProcessing
                                              createAndEditClaimProcessing, 
                                              int CustomerId,
                                              int PolicyId,
                                              int ClaimHeaderId)
        {

            ViewBag.Idcust = CustomerId;
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimProcessings);
                        var claimprocessing = customer.ClaimProcessings.Where(x => x.PolicyId == PolicyId)
                                             .Where(y=>y.ClaimHeaderId==ClaimHeaderId)
                                             .Single(z => z.Id == createAndEditClaimProcessing.Id);

                        _imapper.Map(createAndEditClaimProcessing, claimprocessing);

                        _notyf.Success("Claimsprocessing related to Customer updated Successfully");

                        return RedirectToAction(nameof(List), new { CustomerId, PolicyId,ClaimHeaderId });
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

            createAndEditClaimProcessing.ListStaff = _asyncStaffRepository.FindAll().Select(d => new SelectListItem
            {
                Text = d.FullName,
                Value = d.Id.ToString(),
                Selected = true

            }).Distinct().ToList();

            createAndEditClaimProcessing.ListStage = _asyncClaimProcessingStageRepository.FindAll().Select(d => new SelectListItem
            {
                Text = d.Claim_Status_Name,
                Value = d.Id.ToString(),
                Selected = true

            }).Distinct().ToList();

            ViewBag.Idcust = createAndEditClaimProcessing.CustomerId;
            ViewBag.Idpol = createAndEditClaimProcessing.PolicyId;
            ViewBag.Idclh = createAndEditClaimProcessing.ClaimHeaderId;
            return View("Edit", createAndEditClaimProcessing);
        }

        public async Task<IActionResult> Details(int CustomerId, int PolicyId, int ClaimHeaderId,  int id, string link)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimProcessings);



            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = CustomerId;
            ViewBag.Id = id;
            ViewBag.Idpol = PolicyId;
            ViewBag.Policycode = link;
            ViewBag.Idclh = ClaimHeaderId;

            var claimprocessing = customer.ClaimProcessings.Where(x => x.PolicyId == PolicyId)
                                .Where(y=>y.ClaimHeaderId==ClaimHeaderId)
                                .Single(z => z.Id == id);


            if (customer is null)
            {
                return NotFound();
            }
            var myclaimprocessing = new DisplayClaimProcessing();

            _imapper.Map(claimprocessing, myclaimprocessing);

            myclaimprocessing.Namecustomer = customer.FullName;
            myclaimprocessing.Policycode = link;


            return View(myclaimprocessing);
        }


        // GET: ApartmentController/Delete/5
        public async Task<IActionResult> Delete(int CustomerId, int PolicyId, int ClaimHeaderId, int id)
        {
            var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimProcessings);



            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = CustomerId;
            ViewBag.Id = id;
            ViewBag.Idpol = PolicyId;
            // ViewBag.Policycode = link;
            ViewBag.Idclh = ClaimHeaderId;

            var claimprocessing = customer.ClaimProcessings.Where(x => x.PolicyId == PolicyId)
                                .Where(y => y.ClaimHeaderId == ClaimHeaderId)
                                .Single(z => z.Id == id);


            if (customer is null)
            {
                return NotFound();
            }
            var myclaimprocessing = new DisplayClaimProcessing();

            _imapper.Map(claimprocessing, myclaimprocessing);

            myclaimprocessing.Namecustomer = customer.FullName;
           // myclaimdocument.Policycode = link;


            return View(myclaimprocessing);
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayClaimProcessing displayClaimProcessing,
                int CustomerId, int PolicyId, int ClaimHeaderId)
        {

            await using (await _asyncUnitOfWorkFactory.Create())
            {
                var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimProcessings);
                var claimprocessing = customer.ClaimProcessings.Where(x => x.PolicyId == PolicyId)
                                   .Where(y=>y.ClaimHeaderId==ClaimHeaderId)
                                   .Single(z => z.Id == displayClaimProcessing.Id);

                     customer.ClaimProcessings.Remove(claimprocessing);
                     
                _notyf.Error("Claim Processing related to Customer removed  Successfully");
            }
            return RedirectToAction(nameof(List), new { CustomerId, PolicyId,ClaimHeaderId });
        }
    }
}
