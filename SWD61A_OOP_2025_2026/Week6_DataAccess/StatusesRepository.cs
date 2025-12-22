using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;

namespace Week6_DataAccess
{
    public class StatusesRepository
    {
        private AttendanceDbContext _context; //field of type AttendanceDbContext
        //i.e. through this field we can access directly the database
        public StatusesRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public IQueryable<Status> Get()
        {
            return _context.Statuses;
        }
    }
}
