using ActAPI.Data;
using ActAPI.Models;
using ActAPI.Models.Dto;
using ActAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ActAPI.Services
{
    public class OfflineExamService:IOfflineExamService
    {
        private readonly IDataContext _dataContext;
        private readonly ISectionService _sectionService;

        public OfflineExamService(IDataContext dataContext, ISectionService sectionService)
        {
            _dataContext = dataContext;
            _sectionService = sectionService;
        }

        public async Task Add(OfflineExam obj)
        {
            _dataContext.OfflineExams.Add(obj);
            await _dataContext.SaveChangesAsync();
           
        }

        /// <summary>
        /// Deletes offline exam and all sections, questions, answers connected to it
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task Delete(OfflineExam obj)
        {
            foreach (Section s in obj.Sections)
            {
                await _sectionService.Delete(s);
            }

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

        public List<OfflineExamDetails> GetAllExamDetails()
        {
            List<OfflineExam> offlineExams = _dataContext.OfflineExams.ToList();
            List<OfflineExamDetails> offlineExamDetails = offlineExams.Select(x => new OfflineExamDetails() { Id = x.Id, Name = x.Name, Date = x.Date, StartTime = x.StartTime, EndTime = x.EndTime,SectionsCount=x.Sections.ToList().Count }).ToList();
            return offlineExamDetails.ToList();
        }
        public List<OfflineExamDetails> GetAllExamsBySection(string sectionName)
        {
            List<OfflineExam> offlineExams = _dataContext.OfflineExams.ToList();
            List<OfflineExamDetails> offlineExamDetails = offlineExams.Where(ex=>ex.Sections.ToList().Count==1&&ex.Sections.ToList().FirstOrDefault()?.Name==sectionName).Select(
                x => new OfflineExamDetails() 
                { Id = x.Id, Name = x.Name, Date = x.Date, StartTime = x.StartTime, EndTime = x.EndTime, SectionsCount = x.Sections.ToList().Count }).ToList();
            return offlineExamDetails.ToList();
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
