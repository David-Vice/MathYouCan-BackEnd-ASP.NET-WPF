using ActAPI.Models;

namespace ActAPI.Services.Abstract
{
    public interface IResultService:IBase<Result>
    {
        int? GetGradeByCorrectAnswers(int sectionId, int numberOfCorrectAnswers);
    }
}
