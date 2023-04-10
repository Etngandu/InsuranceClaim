using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.MVC.Models;

namespace ENB.InsuranceAndClaims.MVC.Help
{
    public class InsuranceClaimsProfile : Profile
    {
        public InsuranceClaimsProfile()
        {


            #region Customer 
            CreateMap<Customer, DisplayCustomer>();

            CreateMap<CreateAndEditCustomer, Customer>()
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ForMember(d => d.AddressCustomer, t => t.Ignore());
            CreateMap<Customer, CreateAndEditCustomer>();
            #endregion


            #region Staff
            CreateMap<Staff, DisplayStaff>();

            CreateMap<CreateAndEditStaff, Staff>()
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore());
            CreateMap<Staff, CreateAndEditStaff>();

            #endregion

            #region Identity
            CreateMap<UserRegistrationModel, ApplicationUser>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
            #endregion

            #region Policy 
            CreateMap<Policy, DisplayPolicy>()
              .ForMember(d => d.Customer, t => t.Ignore())
              .ForMember(d => d.PolicyType, t => t.Ignore())
              .ForMember(d => d.PolicyTypeId, t => t.MapFrom(y => y.PolicyTypeId))
              .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId));
            CreateMap<CreateAndEditPolicy, Policy>()
              .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))
              .ForMember(d => d.PolicyTypeId, t => t.MapFrom(y => y.PolicyTypeId))
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ForMember(d => d.Customer, t => t.Ignore())
              .ForMember(d => d.PolicyType, t => t.Ignore());
            CreateMap<Policy, CreateAndEditPolicy>();
            #endregion


            #region PolicyType
            CreateMap<PolicyType, DisplayPolicyType>();

            CreateMap<CreateAndEditPolicyType, PolicyType>()
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore());
            CreateMap<PolicyType, CreateAndEditPolicyType>();

            #endregion

            #region ClaimHeader
            CreateMap<ClaimHeader, DisplayClaimHeader>()
              .ForMember(d => d.Customer, t => t.Ignore())
              .ForMember(d => d.Policy, t => t.Ignore())
              .ForMember(d => d.PolicyId, t => t.MapFrom(y => y.PolicyId))
              .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId));
            CreateMap<CreateAndEditClaimHeader, ClaimHeader>()
              .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))
              .ForMember(d => d.PolicyId, t => t.MapFrom(y => y.PolicyId))
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ForMember(d => d.Policy, t => t.Ignore())
              .ForMember(d => d.Customer, t => t.Ignore());
            CreateMap<ClaimHeader, CreateAndEditClaimHeader>();
            #endregion


            #region ClaimDocument
            CreateMap<ClaimDocument, DisplayClaimDocument>()
              .ForMember(d => d.Customer, t => t.Ignore())
              .ForMember(d => d.Policy, t => t.Ignore())
              .ForMember(d => d.ClaimHeader, t => t.Ignore())
              .ForMember(d => d.PolicyId, t => t.MapFrom(y => y.PolicyId))
              .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))
              .ForMember(d => d.ClaimHeaderId, t => t.MapFrom(y => y.ClaimHeaderId));
            CreateMap<CreateAndEditClaimDocument, ClaimDocument>()
              .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))
              .ForMember(d => d.PolicyId, t => t.MapFrom(y => y.PolicyId))
              .ForMember(d => d.ClaimHeaderId, t => t.MapFrom(y => y.ClaimHeaderId))
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ForMember(d => d.Policy, t => t.Ignore())
              .ForMember(d => d.Customer, t => t.Ignore())
              .ForMember(d => d.ClaimHeader, t => t.Ignore());
            CreateMap<ClaimDocument, CreateAndEditClaimDocument>();
            #endregion

            #region ClaimProcessing
            CreateMap<ClaimProcessing, DisplayClaimProcessing>()
              .ForMember(d => d.Customer, t => t.Ignore())
              .ForMember(d => d.Policy, t => t.Ignore())
              .ForMember(d => d.ClaimHeader, t => t.Ignore())
              .ForMember(d => d.PolicyId, t => t.MapFrom(y => y.PolicyId))
              .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))
              .ForMember(d => d.ClaimHeaderId, t => t.MapFrom(y => y.ClaimHeaderId));
            CreateMap<CreateAndEditClaimProcessing, ClaimProcessing>()
              .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))
              .ForMember(d => d.PolicyId, t => t.MapFrom(y => y.PolicyId))
              .ForMember(d => d.ClaimHeaderId, t => t.MapFrom(y => y.ClaimHeaderId))
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore())
              .ForMember(d => d.Policy, t => t.Ignore())
              .ForMember(d => d.Customer, t => t.Ignore())
              .ForMember(d => d.ClaimHeader, t => t.Ignore());
            CreateMap<ClaimProcessing, CreateAndEditClaimProcessing>();
            #endregion


            #region ClaimProssecingStage 
            CreateMap<ClaimProcessingStage, DisplayClaimProcessingStage>()
              .ForMember(d => d.RepliesProcessingStages, t => t.Ignore())
             .ForMember(d => d.ParentClaimStage, t => t.Ignore());
            CreateMap<CreateAndEditClaimProcessingStage, ClaimProcessingStage>()
              .ForMember(d => d.DateCreated, t => t.Ignore())
              .ForMember(d => d.ParentClaimStage, t => t.Ignore())
              .ForMember(d => d.DateModified, t => t.Ignore());             
            CreateMap<ClaimProcessingStage, CreateAndEditClaimProcessingStage>();
            #endregion
            //#region PatientStaff
            //CreateMap<Staff_Patient_Association, DisplayStaff_Patient_Association>()
            // .ForMember(d => d.StaffId, t => t.MapFrom(y => y.StaffId))
            // .ForMember(d => d.PatientId, t => t.MapFrom(y => y.PatientId))
            // .ForMember(d => d.Staff, t => t.Ignore())
            // .ForMember(d => d.Patient, t => t.Ignore());

            //CreateMap<CreateAndEditStaff_Patient_Association, Staff_Patient_Association>()
            //  .ForMember(d => d.StaffId, t => t.MapFrom(y => y.StaffId))
            //  .ForMember(d => d.PatientId, t => t.MapFrom(y => y.PatientId))
            //  .ForMember(d => d.Staff, t => t.Ignore())
            //  .ForMember(d => d.Patient, t => t.Ignore())
            //  .ReverseMap();

            //#endregion

            //#region Appointment
            //CreateMap<Appointment, DisplayAppointment>()
            // .ForMember(d => d.PatientId, t => t.MapFrom(y => y.PatientId))
            // .ForMember(d => d.StaffId, t => t.MapFrom(y => y.StaffId))
            // .ForMember(d => d.Staff, t => t.Ignore())
            // .ForMember(d => d.Patient, t => t.Ignore());

            //CreateMap<CreateAndEditAppointment, Appointment>()
            //  .ForMember(d => d.PatientId, t => t.MapFrom(y => y.PatientId))
            //  .ForMember(d => d.StaffId, t => t.MapFrom(y => y.StaffId))
            //  .ForMember(d => d.Color, t => t.MapFrom(y => y.EventStatus.ToString()))
            //  .ForMember(d => d.Patient, t => t.Ignore())
            //  .ForMember(d => d.Staff, t => t.Ignore())
            //  .ForMember(d => d.DateCreated, t => t.Ignore())
            //  .ForMember(d => d.DateModified, t => t.Ignore())
            //  .ReverseMap();
            //#endregion


            //#region PatientRecord
            //CreateMap<Patient_Record, DisplayPatientRecord>()
            // .ForMember(d => d.StaffId, t => t.MapFrom(y => y.StaffId))
            // .ForMember(d => d.PatientId, t => t.MapFrom(y => y.PatientId))
            // .ForMember(d => d.Staff, t => t.Ignore())
            // .ForMember(d => d.Patient, t => t.Ignore());

            //CreateMap<CreateAndEditPatientRecord, Patient_Record>()
            //  .ForMember(d => d.StaffId, t => t.MapFrom(y => y.StaffId))
            //  .ForMember(d => d.PatientId, t => t.MapFrom(y => y.PatientId))
            //  .ForMember(d => d.Staff, t => t.Ignore())
            //  .ForMember(d => d.Patient, t => t.Ignore())
            //  .ReverseMap();

            //#endregion
            //#region BookingNotes
            //CreateMap<Booking_Note, DisplayBookingNote>()
            // .ForMember(d => d.Customer, t => t.Ignore())
            // .ForMember(d => d.Booking, t => t.Ignore())            
            // .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))
            // .ForMember(d => d.BookingId, t => t.MapFrom(y => y.BookingId));

            //CreateMap<CreateAndEditBookingNote, Booking_Note>()
            //  .ForMember(d => d.BookingId, t => t.MapFrom(y => y.BookingId))            
            //  .ForMember(d => d.CustomerId, t => t.MapFrom(y => y.CustomerId))
            //  .ForMember(d => d.Customer, t => t.Ignore())
            //  .ForMember(d => d.Booking, t => t.Ignore())              
            //  .ForMember(d => d.DateCreated, t => t.Ignore())
            //  .ForMember(d => d.DateModified, t => t.Ignore())
            //  .ReverseMap();

            //#endregion

            #region Address

            CreateMap<Address, EditAddress>()
                  .ForMember(d => d.CustomerId, t => t.Ignore())
                  .ForMember(d => d.StaffId, t => t.Ignore());
            CreateMap<EditAddress, Address>().ConstructUsing(s => new Address(s.Number_street!, s.City!, s.Zipcode!, s.State_province_county!, s.Country!));
            #endregion
        }
    }
}
