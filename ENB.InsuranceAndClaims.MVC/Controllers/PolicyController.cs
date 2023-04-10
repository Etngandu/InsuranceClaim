using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.InsuranceAndClaims.EF.Repositories;
using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.Entities.Collections;
using ENB.InsuranceAndClaims.Entities.Repositories;
using ENB.InsuranceAndClaims.Infrastructure;
using ENB.InsuranceAndClaims.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Threading.Tasks.Dataflow;

namespace ENB.InsuranceAndClaims.MVC.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IAsyncCustomerRepository _asyncCustomerRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly IAsyncPolicyTypeRepository _asyncPolicyTypeRepository;
        private readonly ILogger<PolicyController> _logger;
        private readonly IMapper _imapper;
        private readonly INotyfService _notifyService;


        public PolicyController(IAsyncCustomerRepository asyncCustomerRepository,
                                IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                IAsyncPolicyTypeRepository asyncPolicyTypeRepository,
                                ILogger<PolicyController> logger,
                                IMapper imapper,
                                INotyfService notyfService)
        {
            _asyncCustomerRepository = asyncCustomerRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _asyncPolicyTypeRepository = asyncPolicyTypeRepository;
            _logger = logger;
            _imapper = imapper;
            _notifyService = notyfService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(int CustomerId)
        {
            ViewBag.Idcust = CustomerId;
            var customer = await _asyncCustomerRepository.FindById(CustomerId);

            ViewBag.Message = customer.FullName;

            return View();
        }


        public async Task<IActionResult> GetPolicies(int CustomerId)
        {

            var customer = (from pol in _asyncCustomerRepository.FindAll().Where(cs => cs.Id == CustomerId).SelectMany(x => x.Policies)
                            join po in _asyncPolicyTypeRepository.FindAll() on pol.PolicyTypeId equals po.Id
                            select new DisplayPolicy
                            {
                             Id=pol.Id,
                             PolicyTypeCode=po.PolicyTypeCode,
                             StartDate=pol.StartDate,
                             EndDate=pol.EndDate,
                             DateCreated=pol.DateCreated,
                             DateModified=pol.DateModified

                            }).ToList();

           // ViewBag.Message = customer.FullName;

            var Mpdata = new List<DisplayPolicy>();

            _imapper.Map(await Task.FromResult(customer), Mpdata);

            return Json(new { data = Mpdata });


        }

        [HttpGet]
        public async Task<IActionResult> Create(int CustomerId)
        {
            ViewBag.Idcust = CustomerId;

            var data = new CreateAndEditPolicy()
            {
                StartDate=DateTime.Today,
                EndDate=DateTime.Today,
                ListPolicyType = _asyncPolicyTypeRepository.FindAll()
                       .Select(d => new SelectListItem
                       {
                           Text = d.PolicyTypeCode,
                           Value = d.Id.ToString(),
                           Selected = true

                       }).Distinct().ToList()



            };

          

            var customer = await _asyncCustomerRepository.FindById(CustomerId);

            ViewBag.Message = customer.FullName;



            return View(data);
        }    
            
           private IEnumerable<SelectListItem>  Malist()
        {



            var ListPolicyType = _asyncPolicyTypeRepository.FindAll()
                        .Select(d => new SelectListItem
                        {
                            Text = d.PolicyTypeCode,
                            Value = d.Id.ToString(),
                            Selected = true

                        }).Distinct().ToList();



            return ListPolicyType;



        }
           

        
        // POST: LawyerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditPolicy createAndEditPolicy, int CustomerId)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var customer = await _asyncCustomerRepository.FindById(CustomerId);

                        Policy policy = new();

                        _imapper.Map(createAndEditPolicy, policy);


                        customer.Policies.Add(policy);

                        _notifyService.Success("Policy  Added  Successfully! ");

                        return RedirectToAction(nameof(List), new { CustomerId });
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
            createAndEditPolicy.ListPolicyType = _asyncPolicyTypeRepository.FindAll().Select(d => new SelectListItem
            {
                Text = d.PolicyTypeCode,
                Value = d.Id.ToString(),
                Selected = true

            }).Distinct().ToList();
            ViewBag.Idcust = createAndEditPolicy.CustomerId;

            return View("Create",createAndEditPolicy);
        }




        public async Task<IActionResult> Edit(int CustomerId, int id)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId,x=>x.Policies);
            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = CustomerId;
            ViewBag.Id = id;



            if (customer is null)
            {
                return NotFound();
            }

            CreateAndEditPolicy data = new()
            {

                ListPolicyType = _asyncPolicyTypeRepository.FindAll().Select(d => new SelectListItem
                {
                    Text = d.PolicyTypeCode,
                    Value = d.Id.ToString(),
                    Selected = true

                }).Distinct().ToList()
             };

            _imapper.Map(customer.Policies.Single(x => x.Id == id), data);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditPolicy createAndEditPolicy, int CustomerId)
        {

            ViewBag.Idcust = CustomerId;
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.Policies);
                        var policy = customer.Policies.Single(x => x.Id == createAndEditPolicy.Id);

                        _imapper.Map(createAndEditPolicy, policy);

                          _notifyService.Success(" Policy updated Successfully");

                        return RedirectToAction(nameof(List), new { CustomerId });
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

            createAndEditPolicy.ListPolicyType = _asyncPolicyTypeRepository.FindAll().Select(d => new SelectListItem
            {
                Text = d.PolicyTypeCode,
                Value = d.Id.ToString(),
                Selected = true

            }).Distinct().ToList();
            ViewBag.Idcust = createAndEditPolicy.CustomerId;
            return View("Edit", createAndEditPolicy);
        }

        public async Task<IActionResult> Details(int customerId, int id)
        {

            var customer = await _asyncCustomerRepository.FindById(customerId);
            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = customerId;
            ViewBag.Id = id;
            

            var lstpolicies = from po in _asyncCustomerRepository.FindAll().Where(x => x.Id == customerId).SelectMany(p => p.Policies)
                              join cust in _asyncCustomerRepository.FindAll() on po.CustomerId equals cust.Id
                              join ptp in _asyncPolicyTypeRepository.FindAll() on po.PolicyTypeId equals ptp.Id
                              select new DisplayPolicy
                          {
                              Id = po.Id,
                              CustomerId = cust.Id,
                              StartDate=po.StartDate,
                              EndDate=po.EndDate,
                              DateCreated=po.DateCreated,
                              DateModified=po.DateModified,
                              PolicyTypeCode = ptp.PolicyTypeCode,
                              Other_Details = po.Other_Details
                              
                          };


            if (lstpolicies is null)
            {
                return NotFound();
            }
            
            var sglPolicy = lstpolicies.Single(x => x.Id == id);

            ViewBag.police = sglPolicy.PolicyTypeCode;

            return View(sglPolicy);
        }


        // GET: ApartmentController/Delete/5
        public async Task<IActionResult> Delete(int customerId, int id)
        {
            var customer = await _asyncCustomerRepository.FindById(customerId);
            ViewBag.Message = customer.FullName;
            ViewBag.Idcust = customerId;
            ViewBag.Id = id;
            

            var lstpolicies = from po in _asyncCustomerRepository.FindAll().Where(x => x.Id == customerId).SelectMany(p => p.Policies)
                              join cust in _asyncCustomerRepository.FindAll() on po.CustomerId equals cust.Id
                              join ptp in _asyncPolicyTypeRepository.FindAll() on po.PolicyTypeId equals ptp.Id
                              select new DisplayPolicy
                              {
                                  Id = po.Id,
                                  CustomerId = cust.Id,
                                  StartDate = po.StartDate,
                                  EndDate = po.EndDate,
                                  DateCreated = po.DateCreated,
                                  DateModified = po.DateModified,
                                  PolicyTypeCode=ptp.PolicyTypeCode,
                                  Other_Details = po.Other_Details

                              };


            if (lstpolicies is null)
            {
                return NotFound();
            }

            var sglPolicy = lstpolicies.Single(x => x.Id == id);
            ViewBag.police = sglPolicy.PolicyTypeCode;

            return View(sglPolicy);
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayPolicy displayPolicy, int CustomerId)
        {
            // ViewBag.Case_Id = caseid;
            await using (await _asyncUnitOfWorkFactory.Create())
            {
                var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.Policies);
                var policy = customer.Policies.Single(x => x.Id == displayPolicy.Id);
               
                customer.Policies.Remove(policy);

               _notifyService.Error("Policy related to Customer removed  Successfully");
            }
            return RedirectToAction(nameof(List), new { CustomerId });
        }
    }
}
