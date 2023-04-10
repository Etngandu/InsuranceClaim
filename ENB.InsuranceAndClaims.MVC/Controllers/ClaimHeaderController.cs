using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.Entities.Repositories;
using ENB.InsuranceAndClaims.Infrastructure;
using ENB.InsuranceAndClaims.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ENB.InsuranceAndClaims.MVC.Controllers
{
    public class ClaimHeaderController : Controller
    {
        private readonly IAsyncCustomerRepository _asyncCustomerRepository;
        private readonly IAsyncPolicyTypeRepository _asyncPolicyTypeRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<ClaimHeaderController> _logger;
        private readonly IMapper _imapper;
        private readonly INotyfService _notyf;
        public ClaimHeaderController(IAsyncCustomerRepository asyncCustomerRepository,
                                      IAsyncPolicyTypeRepository asyncPolicyTypeRepository,
                                      IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                      ILogger<ClaimHeaderController> logger,
                                     IMapper imapper,
                                     INotyfService notyf)
        {
            _asyncCustomerRepository = asyncCustomerRepository;
            _asyncPolicyTypeRepository = asyncPolicyTypeRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _logger = logger;
            _imapper = imapper;
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List(int CustomerId, int PolicyId)
        {
            ViewBag.Idcust = CustomerId;
            ViewBag.Idpol = PolicyId;

            var customer = await _asyncCustomerRepository.FindById(CustomerId, pl => pl.Policies);
            var policy = customer.Policies.Single(x => x.Id == PolicyId);

            ViewBag.Message = customer.FullName;
          //  ViewBag.ArtNumber = policy.PolicyType;

            return View();
        }


        public async Task<IActionResult> GetListClaimHeaders(int CustomerId, int PolicyId)
        {           

            var claimheaderlist = (from ch in _asyncCustomerRepository.FindAll().Where(cs => cs.Id == CustomerId).SelectMany(cs => cs.ClaimHeaders)
                                   .Where(x => x.PolicyId == PolicyId)
                                   join pl in _asyncCustomerRepository.FindAll().Where(cs=>cs.Id==CustomerId).SelectMany(p=>p.Policies) on ch.PolicyId equals pl.Id
                                   join plt in _asyncPolicyTypeRepository.FindAll() on pl.PolicyTypeId equals plt.Id
                                   join cst in _asyncCustomerRepository.FindAll() on ch.CustomerId equals cst.Id                                   
                                   select new DisplayClaimHeader
                                   {
                                       Id = ch.Id,
                                       Ref_Claim_Status = ch.Ref_Claim_Status,
                                       Ref_Claim_Type = ch.Ref_Claim_Type,
                                       DateOfClaim = ch.DateOfClaim,
                                       Date_of_Settlement = ch.Date_of_Settlement,
                                       Amount_Claimed = ch.Amount_Claimed,
                                       Amount_Paid = ch.Amount_Paid,
                                       Namecustomer = cst.FullName,
                                       Policycode = plt.PolicyTypeCode,
                                       Other_Details = ch.Other_Details

                                   }).ToList();


           // var Mpdata = new List<DisplayClaimHeader>();

            var lst = await Task.FromResult(claimheaderlist);

           // _imapper.Map(lst, Mpdata);

            return Json(new { data = lst });


        }

        [HttpGet]
        public async Task<IActionResult> Create(int CustomerId, int PolicyId)
        {
            ViewBag.Idcust = CustomerId;
            ViewBag.Idpol = PolicyId;
            

            var customer = await _asyncCustomerRepository.FindById(CustomerId);


            ViewBag.Message = customer.FullName;

            return View();
        }

        // POST: LawyerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditClaimHeader createAndEditClaimHeader, int CustomerId, int PolicyId)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.Policies);                                       

                        var policy = customer.Policies.Single(x => x.Id == PolicyId);

                         ClaimHeader claimHeader  = new ();

                        _imapper.Map(createAndEditClaimHeader, claimHeader);

                           // customer.ClaimHeaders.Add(claimHeader);
                              policy.ClaimHeaders.Add(claimHeader);

                           _notyf.Success("Lawyer event Added  Successfully! ");

                        return RedirectToAction(nameof(List), new { CustomerId, PolicyId });
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



        public async Task<IActionResult> Edit(int CustomerId, int PolicyId, int id)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimHeaders);
            var claimheader = customer.ClaimHeaders.Where(x => x.PolicyId == PolicyId)
                       .Single(y => y.Id == id);
            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = CustomerId;
            ViewBag.Id = id;
            ViewBag.Idpol = PolicyId;


            if (customer is null)
            {
                return NotFound();
            }

            var data = new CreateAndEditClaimHeader();
            _imapper.Map(claimheader, data);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditClaimHeader createAndEditClaimHeader, int CustomerId,
                                                 int PolicyId)
        {

            ViewBag.Idcust = CustomerId;
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimHeaders);
                        var claimsheader = customer.ClaimHeaders.Where(x => x.PolicyId == PolicyId)
                                            .Single(y => y.Id ==createAndEditClaimHeader.Id);

                        _imapper.Map(createAndEditClaimHeader, claimsheader);

                         _notyf.Success("ClaimHeader related to Customer updated Successfully");

                        return RedirectToAction(nameof(List), new { CustomerId, PolicyId });
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

        public async Task<IActionResult> Details(int CustomerId, int PolicyId, int id, string link)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId,x=>x.ClaimHeaders);
           
                        

            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = CustomerId;
            ViewBag.Id = id;
            ViewBag.Idpol = PolicyId;
            ViewBag.Policycode = link;
          
            var claimheader = customer.ClaimHeaders.Where(x => x.PolicyId == PolicyId)
                               .Single(y => y.Id == id);


            if (customer is null)
            {
                return NotFound();
            }
            var myclaimheader = new DisplayClaimHeader();

             _imapper.Map(claimheader, myclaimheader);

            myclaimheader.Namecustomer = customer.FullName;
            myclaimheader.Policycode = link;


            return View(myclaimheader);
        }


        // GET: ApartmentController/Delete/5
        public async Task<IActionResult> Delete(int CustomerId, int PolicyId, int id)
        {
            var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimHeaders);
            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = CustomerId;
            ViewBag.Id = id;
            ViewBag.Idpol = PolicyId;

            var claimheader = customer.ClaimHeaders.Where(x => x.PolicyId == PolicyId)
                               .Single(y => y.Id == id);


            if (customer is null)
            {
                return NotFound();
            }
            var myclaimheader = new DisplayClaimHeader();

            _imapper.Map(claimheader, myclaimheader);

            return View(myclaimheader);
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayClaimHeader displayClaimHeader,
                int CustomerId, int PolicyId)
        {

            await using (await _asyncUnitOfWorkFactory.Create())
            {
                var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimHeaders);
                var claimheader = customer.ClaimHeaders.Where(x => x.PolicyId == PolicyId)
                                   .Single(y => y.Id == displayClaimHeader.Id);

                customer.ClaimHeaders.Remove(claimheader);

                 _notyf.Error("ClaimHeader related to Customer removed  Successfully");
            }
            return RedirectToAction(nameof(List), new { CustomerId, PolicyId });
        }
    }
}
