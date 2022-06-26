using ActAPI.Data;
using ActAPI.Models;
using ActAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ActAPI.Services
{
    public class SectionService : ISectionService
    {
        private readonly IDataContext _dataContext;
        private readonly IOfflineExamService _offlineExamService;

        public SectionService(IDataContext dataContext, IOfflineExamService offlineExamService)
        {
            _dataContext = dataContext;
            _offlineExamService = offlineExamService;
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

                //OfflineExam? offlineExam = null;
                //if (offlineExam == null) throw new NullReferenceException();

                // adding exam to OfflineExam property of section
                //obj.OfflineExam = _offlineExamService.Get(obj.OfflineExamId.Value).Result; //_dataContext.OfflineExams.Where(x => x.Id == obj.OfflineExamId).FirstOrDefault();

                // adding section to Sections collection of offline exam
                //_dataContext.OfflineExams.Where(x => x.Id == obj.OfflineExamId).FirstOrDefault().Sections.Add(obj);

                // adding section to Sections table of db
                _dataContext.Sections.Add(obj);


                await _dataContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
            
        }

        public async Task Delete(Section obj)
        {
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
