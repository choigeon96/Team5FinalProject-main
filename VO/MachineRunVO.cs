using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class MachineRunVO
    {
    public int run_id             {get;set;}
    public string machine_id         {get;set;}
    public DateTime run_start          {get;set;}
    public DateTime run_end            {get;set;}
    public string ins_date           {get;set;}
    public int ins_emp            {get;set;}
    public string up_date            {get;set;}
    public int up_emp { get; set; }
    }
}
