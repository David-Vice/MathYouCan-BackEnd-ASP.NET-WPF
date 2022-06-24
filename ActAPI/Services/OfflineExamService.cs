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

        /// <summary>
        /// </summary>
        /// <param name="objToUpdate"> Object of type OfflineExam to be updated </param>
        /// <param name="source"> Object of type OfflineExam as source </param>
        /// <returns> Updated object </returns>
        /// <exception cref="NullReferenceException"> Provided objToUpdate had reference to null </exception>
        public async Task<OfflineExam> Update(OfflineExam objToUpdate, OfflineExam source)
        {
            if (objToUpdate != null)
            {
                objToUpdate.StartTime = source.StartTime;
                objToUpdate.EndTime = source.EndTime;
                objToUpdate.Sections = source.Sections;
                objToUpdate.Name = source.Name;
                objToUpdate.Date = source.Date;
                await _dataContext.SaveChangesAsync();
                return objToUpdate;
            }

            throw new NullReferenceException();
        }
    }
}
