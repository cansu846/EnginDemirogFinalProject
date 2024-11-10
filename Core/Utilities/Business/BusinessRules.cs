using Core.Utilities.Results;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //params ile istenilen sayıda parametre girilebilir
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics  )
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
