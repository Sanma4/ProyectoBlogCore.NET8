using BlogCore.Data;
using BlogCore.Models;
using BlogCore.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Inicializador
{
    public class Inicializador : IInicializador
    {
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

        public Inicializador(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Inicializar()
        {
			try
			{
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
			}
			catch (Exception ex)
			{

				throw ex;
			}

            if (_db.Roles.Any(ro => ro.Name == CNT.Administrador)) return;

            //Creo los roles

            _roleManager.CreateAsync(new IdentityRole(CNT.Administrador)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Usuario)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "sanmartinobenjamin@gmail.com",
                Email = "sanmartinobenjamin@gmail.com",
                EmailConfirmed = true,
                Nombre = "Benjamin"
            }, "Admin123*").GetAwaiter().GetResult();


            ApplicationUser usuario = _db.ApplicationUser
            .Where(us => us.Email == "sanmartinobenjamin@gmail.com").FirstOrDefault();

            _userManager.AddToRoleAsync(usuario, CNT.Administrador).GetAwaiter().GetResult();

       
        }
    }
}
