using ActAPI.Data;
using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ActAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IDataContext _dataContext;
        public StudentService(IDataContext dataContext)
        {
            _dataContext = dataContext;

        }
        public async Task Add(Student obj)
        {
            _dataContext.Students.Add(obj);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(Student obj)
        {
            _dataContext.Students.Remove(obj);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Student?> Get(int id)
        {
            return await _dataContext.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student?>> GetAll()
        {
            return await _dataContext.Students.ToListAsync();
        }

        public async Task<Student> Update(Student objToUpdate, Student source)
        {
            if (objToUpdate != null)
            {
                objToUpdate.ExamDate = source.ExamDate;
                objToUpdate.Surname = source.Surname;
                objToUpdate.Name = source.Name;
                objToUpdate.EnglishScore = source.EnglishScore;
                objToUpdate.MathScore = source.MathScore;
                objToUpdate.ReadingScore = source.ReadingScore;
                objToUpdate.ScienceScore = source.ScienceScore;
                objToUpdate.TotalScore = source.TotalScore;
                await _dataContext.SaveChangesAsync();
                return objToUpdate;
            }

            throw new NullReferenceException();
        }
    }
}
