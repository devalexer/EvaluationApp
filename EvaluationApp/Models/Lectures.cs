﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class Lectures
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime LectureDate { get; set; }

        public ICollection<Students> Students { get; set; }

        public int CoursesId { get; set; }
        public string CoursesName { get; set; }
        public Courses Courses { get; set; }

        public ICollection<DataOfUnderstanding> Datapoints { get; set; }
       
    }
}
