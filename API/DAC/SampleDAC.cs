using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace API.DAC
{
    public class SampleDAC : CommonDAC
    {
        /// <summary>
        /// 샘플 Get:
        /// </summary>
        /// <returns></returns>
        public List<SampleVO> GetSample()
        {
            return new List<SampleVO>{ new SampleVO { Name = "test", Value1="sample"}};
        }

    }
}