using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AlquilerApp.Models;
using System;

namespace AlquilerApp.Controllers
{
    public class RenterAPIController: Controller
    {
        private readonly AppDbContext db;
        public RenterAPIController( AppDbContext context ) { this.db = context; }
        public JsonResult GetFee( int idFee )
        {
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");

            if( RenterSession == null ) { return Json("Denied"); }
            else
            {
            Contract contract = db.Contract.Where( c => c.RenterId == RenterSession.Id ).First();
            Fee fee = db.Fee.Where( f => f.Id == idFee && f.ContractId == contract.Id ).First();

            return Json( fee );
            }
        }

        public void ChangeTheme( bool theme )
        {
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");
            Renter UserUpdate = db.Renter.Where( r => r.Id == RenterSession.Id ).First();

            UserUpdate.Theme = theme;
            db.SaveChanges();
        }

        public void ChnageAlertFeeEmit( bool value )
        {
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");
            Renter UserUpdate = db.Renter.Where( r => r.Id == RenterSession.Id ).First();

            UserUpdate.FeeEmitAlert = value;
            db.SaveChanges();
        }

        public void ChangeAlertFeeOverdue( bool value )
        {
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");
            Renter UserUpdate = db.Renter.Where( r => r.Id == RenterSession.Id ).First();

            UserUpdate.FeeOverdueAlert = value;
            db.SaveChanges();
        }

        public void ChangePaymentTicket( bool value )
        {
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");
            Renter UserUpdate = db.Renter.Where( r => r.Id == RenterSession.Id ).First();

            UserUpdate.PaymentTicket = value;
            db.SaveChanges();
        }

        public JsonResult SignFee( int fee ){
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");
            Contract ContractInfo = db.Contract.Where( c => c.RenterId == RenterSession.Id ).First();
            Fee UpdateFee = db.Fee.Where( f => f.ContractId == ContractInfo.Id && f.Id == fee ).First();

            if( UpdateFee.PaymentDate != new DateTime( 0001, 01, 01 ) )
            {
                UpdateFee.Sign = true;
                db.SaveChanges();

                return Json("true");
            }
            else { return Json("false"); }
        }
    }
}