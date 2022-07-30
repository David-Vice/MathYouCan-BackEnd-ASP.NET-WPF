using ActAPI.Data;
using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ActAPI.Services
{
    public class ResultService : IResultService
    {
        private readonly IDataContext _dataContext;
        public ResultService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Add(Result obj)
        {
           
                if (obj.SectionId == null) throw new NullReferenceException();

                _dataContext.Sections.Where(x => x.Id == obj.SectionId).FirstOrDefault().Results.Add(obj);
                _dataContext.Results.Add(obj);

                await _dataContext.SaveChangesAsync();
                
            

            
        }

        public async Task Delete(Result obj)
        {
            _dataContext.Results.Remove(obj);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Result?> Get(int id)
        {
            return await _dataContext.Results.FindAsync(id);
        }

        public async Task<IEnumerable<Result?>> GetAll()
        {
            return await _dataContext.Results.ToListAsync();
        }

        public  int? GetGradeByCorrectAnswers(int sectionId, int numberOfCorrectAnswers)
        {
            return  _dataContext.Results.Where(r => r.SectionId == sectionId && r.CorrectAnswers == numberOfCorrectAnswers).FirstOrDefault()?.Grade;
        }

        public async Task<Result> Update(Result objToUpdate, Result source)
        {
            if (objToUpdate != null)
            {
                objToUpdate.Grade = source.Grade;
                objToUpdate.CorrectAnswers = source.CorrectAnswers;
               
                await _dataContext.SaveChangesAsync();
                return objToUpdate;
            }

            throw new NullReferenceException();
        }

        public async Task AddTable(int sectionId, int tableSize)
        {
            for(int i=0;i<=tableSize;i++)
            {
                Result tmp = new Result() { CorrectAnswers = i, Grade = -1, SectionId = sectionId };
                await Add(tmp);
            }
        }
    }
}
