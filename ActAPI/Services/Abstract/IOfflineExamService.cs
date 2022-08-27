using ActAPI.Models;
using ActAPI.Models.Dto;

namespace ActAPI.Services.Abstract
{
    public interface IOfflineExamService:IBase<OfflineExam>
    {
        List<OfflineExamDetails> GetAllExamDetails();
    }
}
