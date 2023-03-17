﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        //managerleri tasarlarken 
        IBookRepository Book { get; }
        void Save();
    }
}
