using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<Pet> GetPets() {
        //     return new List<Pet>();
        // }

        [HttpGet]
        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets
                .Include(pet => pet.petOwner);
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
        Pet pet = _context.Pets
            .SingleOrDefault(pet => pet.id == id);
        // Return a `404 Not Found` if the pet doesn't exist
        if (pet is null)
        {
            return NotFound();
        }
        return pet;
        }

        [HttpPost]
        public Pet Post(Pet pet)
        {
            pet.checkedInAt = null;

            _context.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        [HttpPut("{id}/checkin")]
        public Pet CheckinPut(int id)
        {
            //Fetch Object data by id
        Pet pet = _context.Pets
        .SingleOrDefault(pet => pet.id == id);
        //Generate timestamp
        DateTime date = DateTime.Now;
        //update Object w/ timestamp
        pet.checkedInAt = date;
        //Update all that
        _context.Update(pet);
        _context.SaveChanges();

        return pet;
        }

        [HttpPut("{id}/checkout")]
        public Pet CheckoutPut(int id)
        {
            //Fetch Object data by id
        Pet pet = _context.Pets
            .SingleOrDefault(pet => pet.id == id);
        //update Object w/ timestamp
        pet.checkedInAt = null;
        //Update all that
        _context.Update(pet);
        _context.SaveChanges();

        return pet;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Pet pet = _context.Pets.Find(id);
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }



        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
