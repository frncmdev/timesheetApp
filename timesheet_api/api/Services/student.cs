using Microsoft.EntityFrameworkCore;
using api.Models;
namespace api.Services
{
    class StudentService : IService
    {
        private TimeSheetContext _context;
        public StudentService()
        {
            _context = new TimeSheetContext();
        }
        public IEnumerable<Student> getAll()
        {
            return _context.Students.ToList();
        }

    }
}