using ContactsAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly DataContext _context;

        public ContactController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> Get()
        {
            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            var hero = await _context.Contacts.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> AddHero(Contact hero)
        {
            _context.Contacts.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Contact>>> UpdateHero(Contact request)
        {
            var dbHero = await _context.Contacts.FindAsync(request.Id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            dbHero.FirstName = request.FirstName;

            //dopisac wszytsko aby nadpisywac ewentualnie 
            await _context.SaveChangesAsync();

            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> Delete(int id)
        {
            var dbHero = await _context.Contacts.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            _context.Contacts.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Contacts.ToListAsync());
        }
    }
}
