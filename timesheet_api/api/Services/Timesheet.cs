using Microsoft.EntityFrameworkCore;
using api.Models;
namespace api.Services
{
    class TimesheetService : IService
    {
        private TimeSheetContext _context;
        public TimesheetService()
        {
            _context = new TimeSheetContext();
        }
    }
}