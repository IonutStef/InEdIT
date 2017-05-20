using System;
using System.Linq;
using InEdITData.Data;

namespace InEdITData
{
    public class StudentData
    {
        public Student GetStudent(Guid studentId)
        {
            using (var context = new InEdItModel())
            {
                return context.Students.FirstOrDefault(s => s.StudentId == studentId);
            }
        }


        public void AddStudent(Student student)
        {
            using (var context = new InEdItModel())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }
    }
}
