﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemo.Repositories
{
    public interface ITransactionRepository<in T>
    {
        public void Message();
    }
}
