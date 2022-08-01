using ActAPI.Models;

namespace ActAPI.Services.Abstract
{
    public interface IQuestionService: IBase<Question>
    {
        Task Add(Question obj,int numberOfAnswers);
    }
}
