﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppNetCore.Shared.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data,string message):base(data,false,message)
        {

        }
        public ErrorDataResult(T data):base(false,data)
        {

        }
        public ErrorDataResult(string message):base(default, false, message)
        {

        }
        public ErrorDataResult() : base(false, default)
        {

        }
    }
}
