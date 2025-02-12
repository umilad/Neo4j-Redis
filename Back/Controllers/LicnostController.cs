using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using System;
using System.Threading.Tasks;
using KrvNijeVoda.Back.Models;
using System.Reflection.Metadata;
using System.Diagnostics;
using KrvNijeVoda.Back;
using MediatR;

//using Bogus;

namespace KrvNijeVoda.Controllers;

[Route("Licnosti")]
[ApiController]
public class LicnostController(IMediator mediator) : ControllerBase
{
    // private readonly Neo4jService _neo4jService;

    // public LicnostController(Neo4jService neo4jService)
    // {
    //     _neo4jService = neo4jService;
    // }
    private readonly MyGraphContext _context;
    public LicnostController(MyGraphContext context)
    {
        _context = context;
    }
   [HttpPost]
    public async Task<IActionResult> CreateLicnost([FromBody] Licnost licnost)
    {

        if (licnost == null)
            return BadRequest("Movie data is required.");

        _context.Licnosti.Add(licnost);
        await _context.SaveChangesAsync();

        return Ok(licnost);
    }

    [HttpPost("DodajLicnost")]
    public async Task<IActionResult> DodajLicnost([FromBody] Licnost licnost, CancellationToken cancellationToken)
    {
        if (licnost == null)
            return BadRequest("Niste uneli podatke.");
        

        if (await _context.Godine.Match(x => x.Where(y => y.ID, licnost.GodinaRodjenja.ID).CountAsync(cancellationToken) == 0))
            return BadRequest("Godina ne postoji!");
            //.UpdateAsync(x => x.Set(request)) //Sets the whole object
        // if(gr == null)
        //      return BadRequest("Godina ne postoji!");

        // await gs =_context.Godine
        //     .Match(x => x.Where(y => y.God, licnost.GodinaSmrti))
        //     .AnyAsync();
        //     //.UpdateAsync(x => x.Set(request)) //Sets the whole object
        // if(gs == null)
        //      return BadRequest("Godina s ne postoji!");


        // await m =_context.Mesta
        //     .Match(x => x.Where(y => y.ID, licnost.MestoRodjenja.ID))
        //     .AnyAsync();
        //     //.UpdateAsync(x => x.Set(request)) //Sets the whole object
        // if(m == null)
        //      return BadRequest("Mesto ne postoji!");

        var l = new Licnost {
            ID = Guid.NewGuid(),
            Titula = licnost.Titula,
            Ime = licnost.Ime,
            Prezime = licnost.Prezime,
            Pol = licnost.Pol,
            Slika = licnost.Slika,
            // GodinaRodjenja = gr.God,
            // GodinaSmrti = gs.God,
            // MestoRodjenja = mr.ID
        };

        _context.Licnosti.Add(licnost);
        await _context.SaveChangesAsync();

        return Ok(licnost);


            // Id = Guid.NewGuid(),
            // FirstName = "Keanu",
            // LastName = "Reeves",
            // MoviesAsActors = new List<Movie> {
            //     new Movie {
            //     Title = "The Matrix"
            //     }
  }
};
        // _context.Licnosti.Add(licnost);
        // await _context.SaveChangesAsync();

        // return Ok(licnost);
    //}








    // [HttpGet("all")]
    // public async Task<IActionResult>  GetAllLicnosti()
    // {
    //     var licnosti = await _context.Licnosti.ToListAsync();
    //     return Ok(licnosti);
    // }
//}

// // ✅ Get all Licnost nodes
//     [HttpGet("all")]
//     public IActionResult GetAllLicnosti()
//     {
//         var licnosti = _context.Licnosti.ToList();
//         return Ok(licnosti);
//     }

// [HttpGet("GetLicnost/{licnostID}")]
// public async Task<IActionResult> GetLicnost(Guid licnostID)
// {
//     try
//     {
//         using (var session = _neo4jService.GetSession())
//         {
//             var query = "MATCH (l:Licnost {ID: $licnostID}) RETURN l.Ime as Ime";
//             var parameters = new { licnostID = licnostID.ToString() };
//             var result = await session.RunAsync(query, parameters);

//             var records = await result.ToListAsync();

//             if (records.Count == 0)
//             {
//                 return NotFound("Licnost not found");
//             }

//             var record = records.SingleOrDefault();

//             // Accessing the properties directly
//            /* var licnostIDValue = record["licnostID"]?.As<string>();

//             if (licnostIDValue == null)
//             {
//                 return StatusCode(500, new 
//                 { 
//                     Error = "Internal Server Error", 
//                     Message = "licnostID is null or not present in the Neo4j record",
//                     DebugInfo = record?.Keys?.ToList() ?? new List<string>()
//                 });
//             }*/

//             return Ok(new 
//             {
//                 Licnost = new Licnost
//                 {
//                     Ime = record["Ime"]?.As<string>(),

//                 },
//             });
//         }
//     }
//     catch (Exception ex)
//     {
//         // Log the error
//         Console.WriteLine($"Error: {ex.Message}");
//         Console.WriteLine($"StackTrace: {ex.StackTrace}");

//         return StatusCode(500, new 
//         { 
//             Error = "Internal Server Error", 
//             Message = ex.Message
//         });
//     }
// }

// [HttpPost("CreateLicnost")]
// public async Task<IActionResult> CreateLicnost([FromBody] Licnost licnost)
// {
//     try
//     {
//         using (var session = _neo4jService.GetSession())
//         {
//             // Example query: "CREATE (u:User {UserId: $userId, UserName: $userName, Email: $email})"
//             var query = "CREATE (l:Licnost {ID: $id, Titula: $titula, Ime: $ime, Prezime: $prezime,  DatumRodjenja: $datumrodjenja, DatumSmrti: $datumsmrti, Pol: $pol, Slika: $slika, MestoRodjenja: $mestorodjenja})";
            
//             var parameters = new
//             {
//                 id= Guid.NewGuid().ToString(),
//                 titula = licnost.Titula,
//                 ime= licnost.Ime,
//                 prezime= licnost.Prezime,
//                 datumrodjenja= licnost.DatumRodjenja,
//                 datumsmrti= licnost.DatumSmrti,
//                 pol= licnost.Pol,
//                 slika= licnost.Slika,
//                 mestorodjenja= licnost.MestoRodjenja
//             };

//             await session.RunAsync(query, parameters);
//         }

//         return CreatedAtAction(nameof(GetLicnost), new { id = licnost.ID }, licnost);
//     }
//     catch (Exception ex)
//     {
//         // Handle exceptions (e.g., log the error)
//         return StatusCode(500, "Internal Server Error");
//     }
// }


   /*[HttpPut("{userId}")]
public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] User user)
{
    using (var session = _neo4jService.GetSession())
    {
        var query = $@"
            MATCH (u:User {{UserId: '{userId}'}})
            SET u.UserName = $userName, 
                u.Email = $email,
                u.Ime = $ime,
                u.Prezime = $prezime,
                u.DatumRodjenja = $datumRodjenja,
                u.Pol = $pol,
                u.MestoRodjenja = $mestoRodjenja,
                u.Slika = $slika
            RETURN u";

        var parameters = new
        {
            userName = user.UserName,
            email = user.Email,
            ime = user.Ime,
            prezime = user.Prezime,
            datumRodjenja = user.DatumRodjenja,
            pol = user.Pol,
            mestoRodjenja = user.MestoRodjenja,
            slika = user.Slika
            // Add other properties as needed
        };

        try
        {
            var result = await session.RunAsync(query, parameters);

            // You can handle the result if needed

            return NoContent();
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}


    [HttpDelete("{userId}")]
public async Task<IActionResult> DeleteUser(Guid userId)
{
    try
    {
        using (var session = _neo4jService.GetSession())
        {
            // Example query: "MATCH (u:User {UserId: $userId}) DETACH DELETE u"
            var query = "MATCH (u:User {UserId: $userId}) DETACH DELETE u";
            
            var parameters = new
            {
                userId = userId.ToString()
            };

            await session.RunAsync(query, parameters);
        }

        return NoContent();
    }
    catch (Exception ex)
    {
        // Handle exceptions (e.g., log the error)
        return StatusCode(500, "Internal Server Error");
    }
}*/
