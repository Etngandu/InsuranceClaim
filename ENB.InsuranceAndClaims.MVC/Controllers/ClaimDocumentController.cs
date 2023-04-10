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
    public class ClaimDocumentController : Controller
    {
        private readonly IAsyncCustomerRepository _asyncCustomerRepository;
        private readonly IAsyncStaffRepository _asyncStaffRepository;
        private readonly IAsyncPolicyTypeRepository _asyncPolicyTypeRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<ClaimDocumentController> _logger;
        private readonly IMapper _imapper;
        private readonly INotyfService _notyf;
        public ClaimDocumentController(IAsyncCustomerRepository asyncCustomerRepository,
                                       IAsyncStaffRepository asyncStaffRepository,
                                      IAsyncPolicyTypeRepository asyncPolicyTypeRepository,
                                      IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                      ILogger<ClaimDocumentController> logger,
                                     IMapper imapper,
                                     INotyfService notyf)
        {
            _asyncCustomerRepository = asyncCustomerRepository;
            _asyncStaffRepository = asyncStaffRepository;
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
        public async Task<IActionResult> List(int CustomerId, int PolicyId, int ClaimHeaderId)
        {
            ViewBag.Idcust = CustomerId;
            ViewBag.Idpol = PolicyId;
            ViewBag.Idclh = ClaimHeaderId;

            var customer = await _asyncCustomerRepository.FindById(CustomerId, pl => pl.ClaimHeaders);
            var claimheader = customer.ClaimHeaders.Where(x => x.PolicyId == PolicyId)
                         .Where(y => y.Id == ClaimHeaderId);

            ViewBag.Message = customer.FullName;
            //ViewBag.ArtNumber = claimheader.;
            //ViewBag.ClailTypecode = claimheader.Ref_Claim_Type;

            return View();
        }


        public async Task<IActionResult> GetListClaimDocument(int CustomerId, int PolicyId, int ClaimHeaderId)
        {

            var claimdocumetlist = _asyncCustomerRepository.FindAll().Where(cs => cs.Id == CustomerId)
                                         .SelectMany(cd => cd.ClaimsDocuments).Where(x => x.PolicyId == PolicyId);

            var claimdoc =    from cd  in  claimdocumetlist.Where(y => y.ClaimHeaderId == ClaimHeaderId)                              
                              join cst in _asyncCustomerRepository.FindAll() on cd.CustomerId equals cst.Id
                              join pl in _asyncCustomerRepository.FindAll().Where(cs => cs.Id == CustomerId).SelectMany(y => y.Policies)
                                   on cd.PolicyId equals pl.Id
                              join plt in _asyncPolicyTypeRepository.FindAll() on pl.PolicyTypeId equals plt.Id
                              join ch in _asyncCustomerRepository.FindAll().Where(cs => cs.Id == CustomerId).SelectMany(y => y.ClaimHeaders)
                                    on cd.ClaimHeaderId equals ch.Id
                                   select new DisplayClaimDocument
                                   {
                                       Id = cd.Id,
                                       Claim_Type = ch.Ref_Claim_Type,
                                       Ref_Document_Type=cd.Ref_Document_Type,
                                       DateCreated = cd.DateCreated,
                                       DateModified = cd.DateModified,
                                       Namecustomer = cst.FullName,
                                       Policycode = plt.PolicyTypeCode,                                      
                                       Other_Details = ch.Other_Details

                                   };




            var lst = await Task.FromResult(claimdoc);

          

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

            var data = new CreateAndEditClaimDocument()
            {
               
                ListStaff = _asyncStaffRepository.FindAll()
                      .Select(d => new SelectListItem
                      {
                          Text = d.FullName,
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
        public async Task<IActionResult> Create(CreateAndEditClaimDocument 
                                                createAndEditClaimDocument, 
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

                        ClaimDocument claimDocument = new();

                        _imapper.Map(createAndEditClaimDocument, claimDocument);

                        claimheader.ClaimsDocuments.Add(claimDocument);

                        _notyf.Success("Claims Document Added  Successfully! ");

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

            createAndEditClaimDocument.ListStaff = _asyncStaffRepository.FindAll().Select(d => new SelectListItem
            {
                Text = d.FullName,
                Value = d.Id.ToString(),
                Selected = true

            }).Distinct().ToList();

            ViewBag.Idcust = createAndEditClaimDocument.CustomerId;
            ViewBag.Idpol = createAndEditClaimDocument.PolicyId;
            ViewBag.Idclh = createAndEditClaimDocument.ClaimHeaderId;
            return View("Create",createAndEditClaimDocument);
        }



        public async Task<IActionResult> Edit(int CustomerId, int PolicyId, int ClaimHeaderId, int id)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimsDocuments);
            var claimdocument = customer.ClaimsDocuments.Where(x => x.PolicyId == PolicyId)
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
         
                 var data = new CreateAndEditClaimDocument()
                 {

                     ListStaff = _asyncStaffRepository.FindAll()
                      .Select(d => new SelectListItem
                      {
                          Text = d.FullName,
                          Value = d.Id.ToString(),
                          Selected = true

                      }).Distinct().ToList()

                 };

            
            _imapper.Map(claimdocument, data);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditClaimDocument
                                              createAndEditClaimDocument, 
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

                        var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimsDocuments);
                        var claimsdocument = customer.ClaimsDocuments.Where(x => x.PolicyId == PolicyId)
                                             .Where(y=>y.ClaimHeaderId==ClaimHeaderId)
                                             .Single(z => z.Id == createAndEditClaimDocument.Id);

                        _imapper.Map(createAndEditClaimDocument, claimsdocument);

                        _notyf.Success("Claimsdocument related to Customer updated Successfully");

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

            createAndEditClaimDocument.ListStaff = _asyncStaffRepository.FindAll().Select(d => new SelectListItem
            {
                Text = d.FullName,
                Value = d.Id.ToString(),
                Selected = true

            }).Distinct().ToList();

            ViewBag.Idcust = createAndEditClaimDocument.CustomerId;
            ViewBag.Idpol = createAndEditClaimDocument.PolicyId;
            ViewBag.Idclh = createAndEditClaimDocument.ClaimHeaderId;
            return View("Edit", createAndEditClaimDocument);
        }

        public async Task<IActionResult> Details(int CustomerId, int PolicyId, int ClaimHeaderId,  int id, string link)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimsDocuments);



            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = CustomerId;
            ViewBag.Id = id;
            ViewBag.Idpol = PolicyId;
            ViewBag.Policycode = link;
            ViewBag.Idclh = ClaimHeaderId;

            var claimdocument = customer.ClaimsDocuments.Where(x => x.PolicyId == PolicyId)
                                .Where(y=>y.ClaimHeaderId==ClaimHeaderId)
                                .Single(z => z.Id == id);


            if (customer is null)
            {
                return NotFound();
            }
            var myclaimdocument = new DisplayClaimDocument();

            _imapper.Map(claimdocument, myclaimdocument);

            myclaimdocument.Namecustomer = customer.FullName;
            myclaimdocument.Policycode = link;


            return View(myclaimdocument);
        }


        // GET: ApartmentController/Delete/5
        public async Task<IActionResult> Delete(int CustomerId, int PolicyId, int ClaimHeaderId, int id)
        {
            var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimsDocuments);



            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = CustomerId;
            ViewBag.Id = id;
            ViewBag.Idpol = PolicyId;
            // ViewBag.Policycode = link;
            ViewBag.Idclh = ClaimHeaderId;

            var claimdocument = customer.ClaimsDocuments.Where(x => x.PolicyId == PolicyId)
                                .Where(y => y.ClaimHeaderId == ClaimHeaderId)
                                .Single(z => z.Id == id);


            if (customer is null)
            {
                return NotFound();
            }
            var myclaimdocument = new DisplayClaimDocument();

            _imapper.Map(claimdocument, myclaimdocument);

            myclaimdocument.Namecustomer = customer.FullName;
           // myclaimdocument.Policycode = link;


            return View(myclaimdocument);
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayClaimDocument displayClaimDocument,
                int CustomerId, int PolicyId, int ClaimHeaderId)
        {

            await using (await _asyncUnitOfWorkFactory.Create())
            {
                var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.ClaimsDocuments);
                var claimdocument = customer.ClaimsDocuments.Where(x => x.PolicyId == PolicyId)
                                   .Where(y=>y.ClaimHeaderId==ClaimHeaderId)
                                   .Single(z => z.Id == displayClaimDocument.Id);

                     customer.ClaimsDocuments.Remove(claimdocument);
                     
                _notyf.Error("ClaimsDocuments related to Customer removed  Successfully");
            }
            return RedirectToAction(nameof(List), new { CustomerId, PolicyId,ClaimHeaderId });
        }
    }
}
