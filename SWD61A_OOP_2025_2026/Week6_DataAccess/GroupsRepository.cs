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

        public Group Get(int id) //when you're searching with the id - expect to return ONE item or null
        {
            return _context.Groups.SingleOrDefault(g => g.Id == id);
        }

        public IQueryable<Group> Get(string name) //there might more than ONE instance having the same starting name
        {
            return _context.Groups.Where(x => x.Name.StartsWith(name));
        }

        public void Add(string name)
        {
            Group myNewGroup = new Group() { Name = name };

            _context.Groups.Add(myNewGroup);
            _context.SaveChanges(); //without this nothing will be saved in the database
        }

        public void Add(Group g)
        {
            _context.Groups.Add(g);
            _context.SaveChanges();
        }

        public void Delete(int id) {

            var myGroupToDelete = Get(id);
            if (myGroupToDelete != null) {
                Delete(myGroupToDelete);
            }
        }
        public void Delete(Group g) {
            _context.Groups.Remove(g); //to delete the group g has to match exactly the details stored in the db
            _context.SaveChanges(); //this permanently saves the changes into the database
        
        }

        public void Update(Group g) {

            _context.SaveChanges();
        }
        public void Update(int id, string name)
        {
            var groupToUpdate = Get(id);
            if (groupToUpdate != null)
            {
                //YOU SHOULD NEVER UPDATE THE PRIMARY KEY

                groupToUpdate.Name = name;
                Update(groupToUpdate);
            }
        }

    }
}
