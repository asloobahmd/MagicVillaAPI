
using MagicVillaAPI_API.Data;
using MagicVillaAPI_API.Models;
using MagicVillaAPI_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly AppDBContext _db;

        public VillaAPIController(AppDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            var villaDomains = _db.Villas.ToList();

            var villaDtos = new List<VillaDTO>();

            foreach (var villaDomain in villaDomains)
            {
                villaDtos.Add(new VillaDTO { 
                    Id = villaDomain.Id,
                    Name = villaDomain.Name,
                    Details = villaDomain.Details,
                    Rate = villaDomain.Rate,
                    Sqft    = villaDomain.Sqft,
                    Occupancy = villaDomain.Occupancy,
                    ImageUrl = villaDomain.ImageUrl,
                    Amenity = villaDomain.Amenity,
                });
            }

            return Ok(villaDtos);
        }


        [HttpGet("{id}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type = typeof(VillaDTO))]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);
            if(villa == null)
            {
                return NotFound();
            }

            VillaDTO villaDtio = new VillaDTO { 
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Rate = villa.Rate,
                Sqft = villa.Sqft,
                Occupancy= villa.Occupancy,
                ImageUrl = villa.ImageUrl,
                Amenity = villa.Amenity,
            };

            return Ok(villaDtio);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if(villaDTO == null || villaDTO.Id is not null)
            {
                return BadRequest();
            }

            var VillaDomain = new Villa { 
                Name = villaDTO.Name,
                Details= villaDTO.Details,
                Rate = villaDTO.Rate,
                Sqft= villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity,
                CreatedDate = DateTime.Now
            };

            _db.Villas.Add(VillaDomain);
            _db.SaveChanges();

            var VillaDto = new VillaDTO
            {
                Id = VillaDomain.Id,
                Name = VillaDomain.Name,
                Details = VillaDomain.Details,
                Rate = VillaDomain.Rate,
                Sqft = VillaDomain.Sqft,
                Occupancy = VillaDomain.Occupancy,
                ImageUrl = VillaDomain.ImageUrl,
                Amenity = VillaDomain.Amenity,
            };

            return CreatedAtAction(nameof(GetVilla), new { id = VillaDomain.Id }, VillaDto);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteVilla(int id)
        {
            if (id <= 0) {
                return BadRequest();
            }

            var villa =  _db.Villas.Find(id);
            if (villa == null)
            {
                return NotFound();
            }

            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }


            var villaDomain = _db.Villas.Find(id);

            if(villaDomain ==null)
            {
                return NotFound();
            }


            var Villa = new Villa
            {
                Id = villaDomain.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity,
                CreatedDate = villaDomain.CreatedDate,
                UpdatedAt = DateTime.Now,
            };

            _db.Entry(villaDomain).CurrentValues.SetValues(Villa);
            _db.SaveChanges();

            return NoContent();

        }
        
    }
}
