using ActAPI.Data;
using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ActAPI.Services
{
    public class OfflineExamService:IOfflineExamService
    {
        private readonly IDataContext _dataContext;
        public OfflineExamService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(OfflineExam obj)
        {
            _dataContext.OfflineExams.Add(obj);
            await _dataContext.SaveChangesAsync();
           
        }

        public async Task Delete(OfflineExam obj)
        {
            //var itemToDelete = await _context.Users.FindAsync(id);
            //if (itemToDelete == null)
            //{
            //    throw new NullReferenceException();
            //}
            _dataContext.OfflineExams.Remove(obj);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<OfflineExam?> Get(int id)
        {
            return await _dataContext.OfflineExams.FindAsync(id);
        }

        public async Task<IEnumerable<OfflineExam?>> GetAll()
        {
            return await _dataContext.OfflineExams.ToListAsync();
        }

        public async Task<OfflineExam> Update(OfflineExam obj)
        {
            //var itemToUpdate = await _context.Users.FindAsync(id);
            //if (itemToUpdate == null)
            //{
            //    throw new NullReferenceException();
            //}
            var result = _dataContext.OfflineExams.SingleOrDefault(e => e.Id == obj.Id);
            if (result != null)
            {
                result.StartTime = obj.StartTime;
                result.EndTime = obj.EndTime;
                result.Sections = obj.Sections;
                result.Name = obj.Name;
                result.Date = obj.Date;
                await _dataContext.SaveChangesAsync();
            }
            return obj;
        }
    }
}
