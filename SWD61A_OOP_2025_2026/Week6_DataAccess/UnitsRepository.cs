using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;

namespace Week6_DataAccess
{
    public class UnitsRepository
    {
        private AttendanceDbContext _context; //field of type AttendanceDbContext
        //i.e. through this field we can access directly the database
        public UnitsRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public IQueryable<Unit> Get()
        {
            return _context.Units;
        }
    }
}
