using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class ShiftVO
    {
     public int  shift_id                                     {get; set;}
     public string  machine_id                                   {get; set;}

     public string  machine_name                              { get; set; }
     public string  shift_type                                {get; set;}
     public string shift_stime                                {get; set;}
     public string shift_etime                                {get; set;}
     public DateTime  shift_sdate                             {get; set;}
     public DateTime shift_edate                              {get; set;}
     public string shift_use                                  {get; set;}
     public string shift_comment                              {get; set;}
     public DateTime ins_date                                 {get; set;}
     public int ins_emp                                    {get; set;}
     public DateTime up_date                                  {get; set;}
     public string up_emp                                     {get; set;}
     public string Directly_Input_Person                         {get; set;}
     public string Indirect_Input_Person                         {get; set;}
     public string Nomal_Direct_WorkTime                         {get; set;}
     public string Nomal_indirect_WorkTime                       {get; set;}
     public string Overtime_Directly_WorkTime                    {get; set;}
     public string Overtime_Indirect_WorkTime                    {get; set;}
     public string Overtime_Directly_Input_Person                {get; set;}
     public string Overtime_Indirect_Input_Person                {get; set;}
     public string Directly_Accident_WorkTime                    {get; set;}
     public string Indirect_Accident_WorkTime                    {get; set;}
     public string Overtime_Directly_Accident_Time               {get; set;}
     public string Overtime_Indirect_Accident_Time               {get; set;}
    }
}
