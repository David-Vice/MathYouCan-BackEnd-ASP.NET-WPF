﻿using ActAPI.Models;
using ActAPI.Models.Dto;

namespace ActAPI.Services.Abstract
{
    public interface IOfflineExamService:IBase<OfflineExam>
    {
        IEnumerable<OfflineExamDetails> GetAllExamDetails();
    }
}
