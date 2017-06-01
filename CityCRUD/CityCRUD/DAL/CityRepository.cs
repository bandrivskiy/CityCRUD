using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityCRUD.DAL
{
    public class CityRepository : ICityRepository
    {
        private readonly CityDBContext _context;

        public CityRepository(CityDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Building> GetBuildings()
        {
            return _context.Buildings.ToList();
        }

        public Building GetBuildingById(int? id)
        {
            return _context.Buildings.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Building build)
        {
            if (build == null)
            {
                throw new ArgumentNullException("Build is null");
            }   
            _context.Buildings.Add(build);
            _context.SaveChanges();
        }

        public void Delete(Building build)
        {
            if (build == null)
            {
                throw new ArgumentNullException("build is null");
            }
            _context.Buildings.Remove(build);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}