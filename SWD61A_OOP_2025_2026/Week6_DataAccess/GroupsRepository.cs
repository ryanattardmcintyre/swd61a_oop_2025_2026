using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;

namespace Week6_DataAccess
{
    public class GroupsRepository
    {
        private AttendanceDbContext _context; //field of type AttendanceDbContext
        //i.e. through this field we can access directly the database
        public GroupsRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public IQueryable<Group> Get()
        {
            return _context.Groups;
        }
    }
}
