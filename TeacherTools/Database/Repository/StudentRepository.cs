using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherTools.Database.Context;
using TeacherTools.Database.Repository.Interfaces;
using TeacherTools.DB.Repository.Repositories;
using TeacherTools.Model;

namespace TeacherTools.Database.Repository
{
    public class StudentRepository : BaseMongoRepository<StudentDocument>, IStudentRepository
    {
        public StudentRepository(IMongoContext context) : base(context)
        {
        }
    }
}
