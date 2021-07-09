using SchoolDB.Domain;
using SchoolDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolDB
{
    public class CommandHelper
    {
        private UnitOfWork unitOfWork;

        public CommandHelper()
        {
            unitOfWork = new UnitOfWork();
        }

        public string[] ParseCommand(string command)
        {
            List<string> delimiters = new List<string> { ":", "," };

            command = Regex.Replace(command, @"\s+", String.Empty);
            string[] parsedCommand = command.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            return parsedCommand;
        }
        public void ExecuteCommand(string[] command)
        {

            switch (command[0])
            {
                case "AddStudent":
                    if (!VerifyID(command[3]))
                    {
                        Console.WriteLine("The ID can only be an 11 digit number");
                    }
                    else if (!VerifyAge(Convert.ToInt32(command[4])))
                    {
                        Console.WriteLine("Age must be in 18-60 range.");
                    }
                    else if (!VerifySex(Convert.ToInt32(command[5])))
                    {
                        Console.WriteLine("1.Female 2.Male");
                    }
                    else
                    {
                        Student student = new Student();
                        student.FirstName = command[1];
                        student.LastName = command[2];
                        student.StudentID = (int)Convert.ToInt64(command[3]);
                        student.Age = Convert.ToByte(command[4]);
                        student.Sex = (Sex)Convert.ToInt32(command[5]);

                        unitOfWork.StudentRepository.Insert(student);
                        unitOfWork.Save();
                    }
                    break;

                case "RemoveStudent":
                    Console.WriteLine("Are you sure you want to remove the student from the database? [y/n]");
                    string option = Console.ReadLine();
                    if (option == "y")
                    {
                        unitOfWork.StudentRepository.Delete((int)Convert.ToInt64(command[1]));
                        unitOfWork.Save();
                    }
                    else
                    {
                        return;
                    }
                    break;

                case "AddSubject":
                    Subject subject = new Subject();
                    subject.SubjectName = command[1];
                    unitOfWork.SubjectRepository.Insert(subject);
                    unitOfWork.Save();
                    break;

                case "AssignStudentToSubject":
                    StudentSubject ss = new StudentSubject();
                    ss.StudentID = Convert.ToInt32(command[1]);
                    ss.SubjectID = Convert.ToInt32(command[2]);
                    unitOfWork.StudentSubjectRepository.Insert(ss);
                    unitOfWork.Save();
                    break;

                case "SetPoint":
                    StudentSubject ssp = unitOfWork.StudentSubjectRepository.GetStudentSubjectByID(Convert.ToInt32(command[1]), Convert.ToInt32(command[2]));
                    ssp.Point = Convert.ToInt32(command[3]);
                    unitOfWork.Save();
                    break;

                case "Get All Points of Student":
                    var spoints = unitOfWork.StudentSubjectRepository.GetStudentPoints(Convert.ToInt32(command[1]));
                    foreach (var item in spoints)
                    {
                        Console.WriteLine(item);
                    }
                    unitOfWork.Save();
                    break;

                case "Get Student's Point in Subject":
                    var stubpoints = unitOfWork.StudentSubjectRepository.GetStudentSubjectByID(Convert.ToInt32(command[1]), Convert.ToInt32(command[2]));
                    Console.WriteLine(stubpoints);
                    break;

                case "Get All Points in Subject":
                    var subpoints = unitOfWork.StudentSubjectRepository.GetSubjectPoints(command[1]);
                    foreach (var item in subpoints)
                    {
                        Console.WriteLine(item);
                    }
                    unitOfWork.Save();
                    break;

                case "Get All Points":
                    var points = unitOfWork.StudentSubjectRepository.GetStudentSubjects();
                    foreach (var item in points)
                    {
                        Console.WriteLine(item);
                    }
                    unitOfWork.Save();
                    break;

                case "Help":
                    Console.WriteLine("1.Add Student: FirstName, LastName, PersonalID, Age, Gender: 1.Female, 2.Male");
                    Console.WriteLine("2.Remove Student: PersonalID");
                    Console.WriteLine("3.Add Subject: Subject Name");
                    Console.WriteLine("4.Assign Student To Subject: SubjectID, PersonalID");
                    Console.WriteLine("5.Set Point: PersonalID, SubjectID, Point");
                    Console.WriteLine("6.Get All Points of Student: PersonalID");
                    Console.WriteLine("7.Get Student's Point in Subject: PersonalID, SubjectID");
                    Console.WriteLine("8.Get All Points in Subject: SubjectID");
                    Console.WriteLine("9.Get All Points");
                    break;

                default:
                    Console.WriteLine("Incorrect Command. Please try again.");
                    break;
            }
        }
        private bool VerifyAge(int age)
        {
            string pattern = @"\b(1[8-9]|[2-5][0-9]|60)\b";
            Regex rg = new Regex(pattern);
            if (rg.IsMatch(age.ToString()))
            {
                return true;
            }
            return false;
        }
        private bool VerifyID(string studentId)
        {
            string pattern = @"\d{11}";
            Regex rg = new Regex(pattern);

            if (rg.IsMatch(studentId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool VerifySex(int sex)
        {
            string pattern = @"\b([1-2])\b";
            Regex rg = new Regex(pattern);
            if (rg.IsMatch(sex.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

