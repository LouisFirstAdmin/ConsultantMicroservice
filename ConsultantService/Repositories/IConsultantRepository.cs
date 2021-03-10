using System;
using System.Collections.Generic;
using System.Text;
using ConsultantData.Model;

namespace ConsultantService.Repositories
{
    public interface IConsultantRepository
    {
        bool AddConsultant(Consultant consultant);
        Consultant GetConsultant(int id);
        IEnumerable<Consultant> GetConsultants();
        bool UpdateConsultant(Consultant consultant);
        bool DeleteConsultant(Consultant consultant);
    }
}
