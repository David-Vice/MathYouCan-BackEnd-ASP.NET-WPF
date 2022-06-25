using ActAPI.Data;
using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ActAPI.Services
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private readonly IDataContext _dataContext;

        public QuestionAnswerService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(QuestionAnswer obj)
        {
            try
            {
                if (obj.QuestionId == null) throw new NullReferenceException();

                _dataContext.Questions.Where(x => x.Id == obj.QuestionId).FirstOrDefault().QuestionAnswers.Add(obj);
                _dataContext.QuestionAnswers.Add(obj);

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
        }

        public async Task Delete(QuestionAnswer obj)
        {
            _dataContext.QuestionAnswers.Remove(obj);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<QuestionAnswer?> Get(int id)
        {
            return await _dataContext.QuestionAnswers.FindAsync(id);
        }

        public async Task<IEnumerable<QuestionAnswer?>> GetAll()
        {
            return await _dataContext.QuestionAnswers.ToListAsync();
        }

        public async Task<QuestionAnswer> Update(QuestionAnswer objToUpdate, QuestionAnswer source)
        {
            if (objToUpdate != null)
            {
                objToUpdate.Type = source.Type;
                objToUpdate.Text = source.Text;
                objToUpdate.PhotoName = source.PhotoName;
                objToUpdate.IsCorrect = source.IsCorrect;

                await _dataContext.SaveChangesAsync();
                return objToUpdate;
            }

            throw new NullReferenceException();
        }
    }
}
