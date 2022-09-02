using Microsoft.EntityFrameworkCore;
using api.Models;
namespace api.Services
{
    class TeacherService : IService
    {
        private TimeSheetContext _context;
        public TeacherService()
        {
            _context = new TimeSheetContext();
        }
    }
}