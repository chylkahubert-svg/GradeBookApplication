using System;
using System.Collections.Generic;
using System.Text;
using GradeBooks.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
           Type = GradeBookType.Standard;
        }
    }
}
