using ActAPI.Data;
using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ActAPI.Services
{
    public class SectionService : ISectionService
    {
        private readonly IDataContext _dataContext;
        private readonly IQuestionService _questionService;
        private readonly IResultService _resultService;

        public SectionService(IDataContext dataContext, IQuestionService questionService,IResultService resultService)
        {
            _dataContext = dataContext;
            _questionService = questionService;
            _resultService = resultService;
        }

        /// <summary>
        /// Adding section to 'Sections' table, connecting offline exam to section
        /// Adding section to 'Sections' property of offline exam
        /// </summary>
        /// <param name="obj">Section to add</param>
        /// <returns></returns>
        public async Task Add(Section obj)
        {
            try
            {
                if (obj.OfflineExamId == null) throw new NullReferenceException();
                _dataContext.Sections.Add(obj);

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
            
        }

        /// <summary>
        /// Deletes section and all questions and answers connected to that quesiton
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task Delete(Section obj)
        {
            foreach (Question q in obj.Questions)
            {
                await _questionService.Delete(q);
            }
            foreach (Result r in obj.Results)
            {
                await _resultService.Delete(r);
            }
            _dataContext.Sections.Remove(obj);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Section?> Get(int id)
        {
            return await _dataContext.Sections.FindAsync(id);
        }

        public async Task<IEnumerable<Section?>> GetAll()
        {

            return await _dataContext.Sections.ToListAsync();
        }

        public async Task<Section> Update(Section objToUpdate, Section source)
        {
            if (objToUpdate != null)
            {
                objToUpdate.Name = source.Name;
                objToUpdate.Duration = source.Duration;
                await _dataContext.SaveChangesAsync();
                return objToUpdate;
            }

            throw new NullReferenceException();
        }
    }
}
