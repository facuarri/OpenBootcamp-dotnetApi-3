using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using universityApiBackend.Models.DataModels;

namespace universityApiBackend
{
    public class Services
    {

        public User FindUserByEmail(List<User> users, string email)
        {
            var userByEmail = from user in users where user.Email == email select user;
            return (User)userByEmail;
        }

        public IEnumerable<Student> FindStudentsOlderThan18(List<Student> students)
        {
            var studentsOlderThan18 = from student in students where (student.Dob >= DateTime.Now.AddYears(-18)) select student;
            return studentsOlderThan18;
        }

        public IEnumerable<Student> FindStudentsWithAtLeastOneCourse(List<Student> students)
        {
            var studentsWithAtLeastOneCourse = from student in students where (student.Courses.Count > 0) select student;
            return studentsWithAtLeastOneCourse;
        }

        public IEnumerable<Course> FindCoursesWithDeterminatedLevelAndOneStudentAtLeast(List<Course> courses, Level level)
        {
            var courseWithDeterminatedLevelAndOneStudentAtLeast = from course in courses where (course.Level == level && course.Students.Count > 0) select course;
            return courseWithDeterminatedLevelAndOneStudentAtLeast;
        }

        public IEnumerable<Course> FindCoursesWithDeterminatedLevelAndCategory(List<Course> courses, Level level, Category category)
        {
            var coursesWithDeterminatedLevelAndCategory = from course in courses where (course.Level == level && course.Categories.Contains(category)) select course;
            return coursesWithDeterminatedLevelAndCategory;
        }

        public IEnumerable<Course> FindCoursesWithoutStudents(List<Course> courses)
        {
            var coursesWithoutStudents = from course in courses where course.Students.Count == 0 select course;
            return coursesWithoutStudents;
        }

    }
}
