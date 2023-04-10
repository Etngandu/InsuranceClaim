using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.Entities.Repositories;
using ENB.InsuranceAndClaims.Infrastructure;
using ENB.InsuranceAndClaims.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace ENB.InsuranceAndClaims.MVC.Controllers
{
   // [Authorize]
    public class AddressesController : Controller
    {
        private readonly IAsyncCustomerRepository _asyncCustomerRepository;
        private readonly IAsyncStaffRepository _asyncStaffRepository;        
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;


        /// <summary>
        /// Initializes a new instance of the AddressesController class.
        /// </summary>
        public AddressesController(IAsyncCustomerRepository asyncCustomerRepository,
                                   IAsyncStaffRepository asyncStaffRepository,                                   
                                   IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                   IMapper mapper,
                                   INotyfService notyf)
        {
            _asyncCustomerRepository = asyncCustomerRepository;           
            _asyncStaffRepository = asyncStaffRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _mapper = mapper;
            _notyf = notyf;
        }

        public async Task<IActionResult> Edit(int CustomerId, int StaffId)
        {
            ViewBag.CustId = CustomerId;
            ViewBag.StaffId = StaffId;
           
            
            var address = new Address();
            var message = "";

            if (CustomerId != 0)
            {
                var customer = await _asyncCustomerRepository.FindById(CustomerId);
                if (customer is null)
                {
                    return NotFound();
                }
                address = customer.AddressCustomer;
                message = customer.FullName;
            }

            if (StaffId != 0)
            {
                var staff = await _asyncStaffRepository.FindById(StaffId);
                if (staff is null)
                {
                    return NotFound();
                }
                address = staff.AddressStaff;
                message = staff.FullName;
            }

            

            var data = new EditAddress();

            ViewBag.Message = message;

            _mapper.Map(address, data);
            return View(data);
        }

        public  IActionResult Redirect(int CustomerId, int StaffId)
        {
            ViewBag.CustId = CustomerId;
            ViewBag.StaffId = StaffId;
            var redirect= RedirectToAction("");

        //  private ActionResult result { get; set; }=ActionResult.
            

            if (CustomerId != 0)
            {
              redirect=  RedirectToAction("Index","Customer");
            }

            if (StaffId != 0)
            {
              redirect=  RedirectToAction("Index","Staff");
            }


            return redirect;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAddress editAddressModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        if (editAddressModel.CustomerId != 0)
                        {
                            var customer = await _asyncCustomerRepository.FindById(editAddressModel.CustomerId);
                            _mapper.Map(editAddressModel, customer.AddressCustomer);

                            _notyf.Success("Address created  Successfully! ");

                            return RedirectToAction(nameof(Index), "Customer");
                        }

                        if (editAddressModel.StaffId != 0)
                        {
                            var staff = await _asyncStaffRepository.FindById(editAddressModel.StaffId);
                            _mapper.Map(editAddressModel, staff.AddressStaff);

                            _notyf.Success("Address created  Successfully! ");

                            return RedirectToAction(nameof(Index), "Staff");
                        }                       


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
    }
}
