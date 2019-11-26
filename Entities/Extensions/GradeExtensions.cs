using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class GradeExtensions
    {
        public static void Map(this Grade dbGrade, Grade grade)
        {
            dbGrade.GradeName = grade.GradeName;
            dbGrade.IsActive = grade.IsActive;
        }
    }
}
