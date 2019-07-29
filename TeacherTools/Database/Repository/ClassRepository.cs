using System;
using System.Collections.Generic;
using System.Text;
using TeacherTools.Database.Context;
using TeacherTools.DB.Repository.Interfaces;
using TeacherTools.DB.Repository.Repositories;
using TeacherTools.Model;

namespace TeacherTools.DB.Repository
{
    public class ClassRepository : BaseMongoRepository<ClassDocument>, IClassRepository
    {
        public ClassRepository(IMongoContext context) : base(context)
        {
        }
    }
}
