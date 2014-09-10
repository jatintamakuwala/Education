using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Education.Implementation
{
    public interface IEducationRepository : IDisposable
    {
        #region ClassMst
        void AddClassMst(ClassMst ClassMst);
        void UpdateClassMst(ClassMst ClassMst);
        void DeleteClassMst(ClassMst ClassMst);
        IQueryable<ClassMst> ClassMsts { get; }
        #endregion

        #region Professor
        void AddProfessor(Professor Professor);
        void UpdateProfessor(Professor Professor);
        void DeleteProfessor(Professor Professor);
        IQueryable<Professor> Professors { get; }
        #endregion

        #region Student
        void AddStudent(Student Student);
        void UpdateStudent(Student Student);
        void DeleteStudent(Student Student);
        IQueryable<Student> Students { get; }
        #endregion

        void SaveChanges();
        
    }
}
