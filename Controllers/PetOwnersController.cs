using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<PetOwner> GetPets() {
        //     return new List<PetOwner>();
        // }

        [HttpGet]
        public IEnumerable<PetOwner> GetAll()
        {
            return _context.PetOwners;
        }

        [HttpPost]
        public PetOwner Post(PetOwner petowner)
        {
            _context.Add(petowner);
            _context.SaveChanges();
            return petowner;
        }
        
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
            PetOwner petowner = _context.PetOwners
                .SingleOrDefault(petowner => petowner.id == id);
              // SELECT * FROM Bakers
              //   WHERE Baker.id = $1

          // Return a `404 Not Found` if the baker doesn't exist
            if (petowner is null)
            {
                return NotFound();
            }

            return petowner;
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PetOwner petowner = _context.PetOwners.Find(id);
            _context.PetOwners.Remove(petowner);
            _context.SaveChanges();
        }
    }
}
