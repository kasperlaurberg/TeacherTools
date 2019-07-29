using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherTools.Model
{
    public interface IDocument
    {
        ObjectId Id { get; set; }
    }
}
