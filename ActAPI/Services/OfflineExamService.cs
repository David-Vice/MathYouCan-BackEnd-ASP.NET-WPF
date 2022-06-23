using ActAPI.Data;

namespace ActAPI.Services
{
    public class OfflineExamService
    {
        private readonly IDataContext _dataContext;
        public OfflineExamService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
    }
}
