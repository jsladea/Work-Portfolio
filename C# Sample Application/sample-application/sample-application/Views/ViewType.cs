using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleApp.Views
{
    public class ViewType
    {

        public static readonly ViewType Department = new ViewType("Department");
        public static readonly ViewType Employee = new ViewType("Employee");
        public static readonly ViewType Individual = new ViewType("Individual");

        public static IEnumerable<ViewType> Values
        {
            get
            {
                yield return Department;
                yield return Employee;
                yield return Individual;
            }
        }

        public static ViewType GetByName(string name)
        {
            foreach (ViewType type in Values)
                if (type.Name == name)
                    return type;
            return null;
        }

        public string Name { get; private set; }
        private ViewType(string name)
        {
            Name = name;
        }
    }
}
