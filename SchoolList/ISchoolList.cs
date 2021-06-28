using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolList
{
    interface ISchoolList
    {
        void AddPerson(string name);

        void SetPoint(string name, int point);

        void RemovePerson(string name);

        void GetPersonPoint(string name);
    }
}
