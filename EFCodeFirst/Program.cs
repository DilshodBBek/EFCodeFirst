using EFCodeFirst.Domain.Models;
using Infrastucture.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            KundalikDbContext _db = new();
            //_db.Students.Where(x => true).ToList().ForEach(x => { Console.WriteLine(x); });

            var result = from item in _db.StudentTeachers
                         join st in _db.Students
                         on item.Student.StudentId equals st.StudentId
                         join t in _db.Teachers
                         on item.Teacher.TeacherId equals t.TeacherId
                         join s in _db.Subjects
                         on item.Subject.SubjectId equals s.SubjectId
                         select new StudentTeacher()
                         {
                             Id = item.Id,
                             Student = st,
                             Subject = s,
                             Teacher = t
                         };

            //var res = _db.StudentTeachers
            //           .Join(_db.Students, x => x.Student.StudentId, st => st.StudentId, (x, st) => new { StudentTeacher = x, Student = st })
            //           .Join(_db.Teachers, steacher => steacher.StudentTeacher.Teacher.TeacherId, t => t.TeacherId, (steacher, t) => new { steacher.StudentTeacher, t.t })
            //           .Join(_db.Subjects, st => st.StudentTeacher.StudentTeacher.Subject.SubjectId, s => s.SubjectId, (st, sub) => new { StudentTeacher = st, Subject = sub })
            //           .Select((a, b, c) => new StudentTeacher() { Student = c, Subject = a.Subject, Teacher = b });

            var result1 = _db.StudentTeachers
    .Join(_db.Students, item => item.Student.StudentId, st => st.StudentId, (item, st) => new { item, st })
    .Join(_db.Teachers, temp => temp.item.Teacher.TeacherId, t => t.TeacherId, (temp, t) => new { temp.item, temp.st, t })
    .Join(_db.Subjects, temp => temp.item.Subject.SubjectId, s => s.SubjectId, (temp, s) => new { temp.item.Id, temp.st, temp.t, s })
    .Select(temp => new StudentTeacher()
    {
        Id = temp.Id,
        Student = temp.st,
        Subject = temp.s,
        Teacher = temp.t
    });

            IEnumerable<StudentTeacher> result2 = _db.StudentTeachers.Where(x => true)
                            .Include(x => x.Student);

            var res = _db.Students.sq.SqlQuery("Select * from Students where FirstName ='Bill'").ToList();



            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

        }

        private static void AddData(KundalikDbContext _db)
        {
            List<Student> students = InitializeStudentsList();
            List<Teacher> teachers = InitializeTeachersList();
            List<Subject> subjects = InitializeSubjectsList();

            List<StudentTeacher> studentTeachers = InitializeStudentTeachersList();

            _db.AddRange(students);
            _db.AddRange(teachers);
            _db.AddRange(subjects);
            _db.AddRange(studentTeachers);



            _db.SaveChanges();

            List<StudentTeacher> InitializeStudentTeachersList()
            {
                return new()
                {
                    new()
                    {
                        Student=students[0],//Bahodirov Azam
                        Subject=subjects[1],//Kimyo
                        Teacher=teachers[1] //Nurmatov Do`stmurod
                    },
                     new()
                    {
                        Student=students[2],//Boltavoyov Musk
                        Subject=subjects[0],//Fizika
                        Teacher=teachers[0]//Davlatov Tursunxoja
                    },
                      new()
                    {
                        Student=students[1],//Alex Eshmatov
                        Subject=subjects[2],//Matematika
                        Teacher=teachers[2]//Esonov Nasibali
                    },
                };
            }
        }

        private static List<Subject> InitializeSubjectsList()
        {
            return new()
            {
                new()
                {
                    SubjectName="Fizika"
                },
                new()
                {
                    SubjectName="Kimyo"
                },
                new()
                {
                    SubjectName="Matematika"
                },
                new()
                {
                    SubjectName="Jismoniy tarbiya"
                }
            };
        }

        private static List<Teacher> InitializeTeachersList()
        {
            return new()
            {
                new()
                {
                    FullName="Davlatov Tursunxoja",
                    BirthDate = new DateTime (1985, 03, 15)
                },
                new()
                {
                    FullName="Nurmatov Do`stmurod",
                    BirthDate = new DateTime (1985, 03, 15)
                },
                new()
                {
                    FullName="Esonov Nasibali",
                    BirthDate =     new DateTime (1985, 03, 15)
                },
            };
        }

        private static List<Student> InitializeStudentsList()
        {
            return new()
            {
                new ()
                {
                     FullName = "Bahodirov Azam",
                     BirthDate = new DateTime(1995, 05, 01)
                },
                new()
                {
                     FullName = "Alex Eshmatov",
                     BirthDate =new DateTime(1995, 05, 01)
                },
                new()
                {
                     FullName = "Boltavoyov Musk",
                     BirthDate = new DateTime (1995, 05, 01)
                },
                new()
                {
                     FullName = "Qochqorov Geyts",
                     BirthDate = new DateTime (1995, 05, 01)
                }
            };
        }
    }
}