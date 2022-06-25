using ActAPI.Data;
using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ActAPI.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IDataContext _dataContext;

        public QuestionService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(Question obj)
        {
            try
            {
                if (obj.SectionId == null) throw new NullReferenceException();

                _dataContext.Sections.Where(x => x.Id == obj.SectionId).FirstOrDefault().Questions.Add(obj);
                _dataContext.Questions.Add(obj);

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
        }

        public async Task Delete(Question obj)
        {
            _dataContext.Questions.Remove(obj);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Question?> Get(int id)
        {
            return await _dataContext.Questions.FindAsync(id);
        }

        public async Task<IEnumerable<Question?>> GetAll()
        {
            return await _dataContext.Questions.ToListAsync();
        }

        public async Task<Question> Update(Question objToUpdate, Question source)
        {
            if (objToUpdate != null)
            {
                objToUpdate.Type = source.Type;
                objToUpdate.QuestionContent = source.QuestionContent;
                objToUpdate.Text = source.Text;
                objToUpdate.PhotoName = source.PhotoName;

                //_dataContext.Questions.Update(source);
                await _dataContext.SaveChangesAsync();
                return objToUpdate;
            }

            throw new NullReferenceException();
        }
    }
}
