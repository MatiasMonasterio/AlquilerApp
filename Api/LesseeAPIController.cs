using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AlquilerApp.Models;
using System;

namespace AlquilerApp.Controllers
{
    public class LesseeAPIController: Controller
    {
        private readonly AppDbContext db;
        public LesseeAPIController( AppDbContext context )
        {
            this.db = context;
        }

        public JsonResult GetFee( int idFee, int idDepartment )
        {
            Lessee user = HttpContext.Session.Get<Lessee>("LesseeSession");
            Department department = db.Department.Where( d => d.Id == idDepartment && d.LesseeId == user.Id ).First();

            if( user == null && department == null ) { return Json("Denied"); }
            else
            {
            Contract contract = db.Contract.Where( c => c.DepartmentId == idDepartment ).First();
            Fee fee = db.Fee.Where( f => f.Id == idFee && f.ContractId == contract.Id ).First();

            return Json( fee );
            }
        }

        [HttpPost]
        public JsonResult AddAditionalAmount ( AditionalAmount AditionalInfo )
        {
            Console.WriteLine( AditionalInfo );
            AditionalAmount aditional = new AditionalAmount(){
                Description = AditionalInfo.Description,
                amount = AditionalInfo.amount,
                FeeId = AditionalInfo.FeeId
            };

            db.AditionalAmount.Add( aditional );
            db.SaveChanges();

            return Json( "Ok" );
        }

        public void ChangeTheme( bool theme )
        {
            Lessee User = HttpContext.Session.Get<Lessee>("LesseeSession");
            Lessee UserUpdate = db.Lessee.Where( r => r.Id == User.Id ).First();

            UserUpdate.Theme = theme;
            db.SaveChanges();
        }

        public void ChnageAlertFeeEmit( bool value )
        {
            Lessee User = HttpContext.Session.Get<Lessee>("LesseeSession");
            Lessee UserUpdate = db.Lessee.Where( r => r.Id == User.Id ).First();

            UserUpdate.FeeEmitAlert = value;
            db.SaveChanges();
        }

        public void ChangeAlertFeeOverdue( bool value )
        {
            Lessee User = HttpContext.Session.Get<Lessee>("LesseeSession");
            Lessee UserUpdate = db.Lessee.Where( r => r.Id == User.Id ).First();

            UserUpdate.FeeOverdueAlert = value;
            db.SaveChanges();
        }

        public void ChangePaymentTicket( bool value )
        {
            Lessee User = HttpContext.Session.Get<Lessee>("LesseeSession");
            Lessee UserUpdate = db.Lessee.Where( r => r.Id == User.Id ).First();

            UserUpdate.PaymentTicket = value;
            db.SaveChanges();
        }
    }
}