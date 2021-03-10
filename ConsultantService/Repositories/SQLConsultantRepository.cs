using System;
using System.Collections.Generic;
using System.Text;
using ConsultantData.Model;

namespace ConsultantService.Repositories
{
    public class SQLConsultantRepository : IConsultantRepository
    {
        readonly private ConsultantContext context;

        public SQLConsultantRepository(ConsultantContext context)
        {
            this.context = context;
        }

        public void AddConsultant(Consultant consultant)
        {
            context.Consultants.Add(consultant);
            context.SaveChanges();
        }

        public void DeleteConsultant(Consultant consultant)
        {
            context.Consultants.Remove(consultant);
            context.SaveChanges();
        }

        public Consultant GetConsultant(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (context.Consultants.Find(id) == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return context.Consultants.Find(id);
        }

        public IEnumerable<Consultant> GetConsultants()
        {
            return context.Consultants;
        }

        public void UpdateConsultant(Consultant consultant)
        {
            context.Consultants.Update(consultant);
            context.SaveChanges();
        }
    }
}
