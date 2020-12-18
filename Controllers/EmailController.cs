using Microsoft.AspNetCore.Mvc;
using AlquilerApp.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlquilerApp.Controllers
{
    public class EmailController: Controller
    {
        private readonly AppDbContext db;
        public EmailController( AppDbContext context ) { this.db = context; }

        public void FeeEmit()
        {
            List<Renter> RenterList = db.Renter.Where( r => r.FeeEmitAlert == true ).ToList();

            foreach( var Renter in RenterList )
            { EmailConfig.FeeEmit( Renter.Email ); }
        }

        public void FeeExpiry()
        {
            List<Renter> RentersOverdue = db.Renter.FromSqlRaw("SELECT * FROM RentersOverdue").ToList();

            foreach( var Renter in RentersOverdue )
            { EmailConfig.FeeOverdue( Renter.Email ); }
        }
    }
}