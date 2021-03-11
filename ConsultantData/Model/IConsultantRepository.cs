using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantData.Model
{
    public interface IConsultantRepository
    {
        void AddConsultant(Consultant consultant);
        Consultant GetConsultant(int id);
        IEnumerable<Consultant> GetConsultants();
        void UpdateConsultant(Consultant consultant);
        void DeleteConsultant(Consultant consultant);
    }
}
