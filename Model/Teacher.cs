using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Teacher
    { 
        public string Name { get; set; }
        public int Id { get; set; }
        
        public List<Student> Students { get; set; } 
        

        public Teacher()
        {
            this.Students = new List<Student>();
        }
    }
}
