using System;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Data.EntityModel;
using System.Collections.Generic;

namespace Education.Implementation
{
	public class EducationRepository : IEducationRepository
	{
		public readonly EducationEntities EducationContext;
		public EducationRepository()
		{
			EducationContext= new EducationEntities();
		}
	
		#region ClassMst 
        // Adding ClassMst object 
		public void AddClassMst(ClassMst ClassMst)
		{
			EducationContext.ClassMst.Add(ClassMst);
		}
        // Upadte ClassMst object 
		public void UpdateClassMst(ClassMst ClassMst)
		{
            // Find the entry State for the object 
			var entry = EducationContext.Entry<ClassMst>(ClassMst);
			if(entry.State == EntityState.Detached)
			{
                // entry.State is detached than Find the entity and attach it.
				long ClassMstID = ClassMst.ClassMstID;
				ClassMst attachedEntity = EducationContext.ClassMst.Where(x => x.ClassMstID == ClassMstID).First();
                // save the new context values to the entity if not null
				if (attachedEntity != null)
					EducationContext.Entry(attachedEntity).CurrentValues.SetValues(ClassMst); 
				else
					entry.State = EntityState.Modified;
                // or else modify its state.
			}
		}
        // Delete ClassMst object 
		public void DeleteClassMst(ClassMst ClassMst)
		{
			EducationContext.Set<ClassMst>().Attach(ClassMst);
			EducationContext.Entry<ClassMst>(ClassMst).State = EntityState.Deleted;
		}
        // Fetch all the ClassMst Entries
		public IQueryable<ClassMst> ClassMsts  
		{
			get { return EducationContext.ClassMst; } 
		}
	
		#endregion 
	
		#region Professor
		public void AddProfessor(Professor Professor)
		{
			EducationContext.Professor.Add(Professor);
		}
		public void UpdateProfessor(Professor Professor)
		{
			var entry = EducationContext.Entry<Professor>(Professor);
			if(entry.State == EntityState.Detached)
			{
				long ProfessorID = Professor.ProfessorID;
				Professor attachedEntity = EducationContext.Professor.Where(x => x.ProfessorID == ProfessorID).First();
				if (attachedEntity != null)
					EducationContext.Entry(attachedEntity).CurrentValues.SetValues(Professor); 
				else
					entry.State = EntityState.Modified;

			}
		}
		public void DeleteProfessor(Professor Professor)
		{
			EducationContext.Set<Professor>().Attach(Professor);
			EducationContext.Entry<Professor>(Professor).State = EntityState.Deleted;
		}
		public IQueryable<Professor> Professors  
		{
			get { return EducationContext.Professor; } 
		}
	
		#endregion 
	
		#region Student
		public void AddStudent(Student Student)
		{
			EducationContext.Student.Add(Student);
		}
		public void UpdateStudent(Student Student)
		{
			var entry = EducationContext.Entry<Student>(Student);
			if(entry.State == EntityState.Detached)
			{
				long StudentID = Student.StudentID;
				Student attachedEntity = EducationContext.Student.Where(x => x.StudentID == StudentID).First();
				if (attachedEntity != null)
					EducationContext.Entry(attachedEntity).CurrentValues.SetValues(Student); 
				else
					entry.State = EntityState.Modified;
			}
		}
		public void DeleteStudent(Student Student)
		{
			EducationContext.Set<Student>().Attach(Student);
			EducationContext.Entry<Student>(Student).State = EntityState.Deleted;
		}
		public IQueryable<Student> Students  
		{
			get { return EducationContext.Student; } 
		}
        #endregion

        public void SaveChanges()
		{
			try
			{
				EducationContext.SaveChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	
		public void Dispose()
		{
			if(EducationContext!= null)
				EducationContext.Dispose();
		}
	}

}

