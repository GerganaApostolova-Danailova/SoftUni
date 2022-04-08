using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        IList<IPrivate> Privates { get; }
    }
}
