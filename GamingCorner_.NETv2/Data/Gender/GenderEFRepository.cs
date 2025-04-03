    namespace GamingCorner.Data;

    using GamingCorner.Models;
    using System.Text.Json;
    using System.Data.SqlClient;
    using System.Data;
    using GamingCorner.Data;
    using Microsoft.EntityFrameworkCore;

    public class GenderEFRepository : IGenderRepository
    {


        private readonly GamingCornerContext _context;

        public GenderEFRepository(GamingCornerContext context)
        {

            _context = context;
        }

        public List<GenderDTO> GetAll()
        {
            var genders = _context.Genders
                .ToList();

            if (genders != null)
            {
                var genderDto = genders.Select(g => new GenderDTO
                {
                    GenderId = g.GenderId,
                    Name = g.Name,
                }).ToList();
                return genderDto;
            }
            else
            {
                return null;
            }
        }

        public void Add(Gender gender)
        {
            _context.Genders.Add(gender);
            SaveChanges();
        }

        public GenderDTO Get(int id)
        {
            var gender = _context.Genders
                .Where(gender => gender.GenderId == id)
                .FirstOrDefault();

            if (gender != null)
            {
                var genderDto = new GenderDTO
                {
                    GenderId = gender.GenderId,
                    Name = gender.Name,
                };
                return genderDto;
            }
            else
            {
                return null;
            }
        }

        public List<Videogame> GetVideogamesByGender (int id)
        {
            return _context.Videogames
                           .Where(v => v.GenderId == id)
                           .ToList();    
        }

        public void Update(Gender gender)
        {
            var existingGender = _context.Genders.Find(gender.GenderId);

            if (existingGender != null)
            {
                _context.Entry(existingGender).CurrentValues.SetValues(gender);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var genderDto = Get(id);
            if (genderDto == null)
            {
                throw new KeyNotFoundException("Gender not found.");
            }
            var gender = _context.Genders.FirstOrDefault(g => g.GenderId == id);
            if (gender != null)
            {
                _context.Genders.Remove(gender);
                SaveChanges();
            }

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
