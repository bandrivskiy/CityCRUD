using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCRUD.DAL
{
   public interface ICityRepository
    {
        IEnumerable<Building> GetBuildings();
        Building GetBuildingById(int? id);
        void Insert(Building build);
        void Delete(Building build);
        void Save();

    }
}
