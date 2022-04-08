using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public IList<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine("Privates:");

            foreach (var @private in privates)
            {
                sb.AppendLine($"  {@private}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
