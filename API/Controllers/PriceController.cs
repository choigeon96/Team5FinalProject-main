using API.DAC;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VO;
namespace API.Controllers
{
    public class PriceController : ApiController
    {
        PriceDAC dac = new PriceDAC();
        // GET: api/Sample
        [Route("api/price/{priceType}")]
        public IHttpActionResult GetPriceList(string priceType)
        {
            ApiMessage<List<PriceVO>> msg = new ApiMessage<List<PriceVO>>();
            msg.Data = dac.GetItemPrice(priceType);
            msg.ResultCode = (msg.Data == null) ? "F" : "S";
            msg.ResultMessage = (msg.Data == null) ? "조회된 목록이 없습니다." : "OK";

            return Ok(msg);
        }
        [Route("api/price/companyList")]
        public IHttpActionResult GetCompanyList()
        {
            ApiMessage<List<CompanyCodeVO>> msg = new ApiMessage<List<CompanyCodeVO>>();
            msg.Data = dac.GetCompanyList();
            msg.ResultCode = (msg.Data == null) ? "F" : "S";
            msg.ResultMessage = (msg.Data == null) ? "조회된 목록이 없습니다." : "OK";

            return Ok(msg);
        }

        [Route("api/price/itemList")]
        public IHttpActionResult GetItemList()
        {
            ApiMessage<List<ItemCodeVO>> msg = new ApiMessage<List<ItemCodeVO>>();
            msg.Data = dac.GetItemList();
            msg.ResultCode = (msg.Data == null) ? "F" : "S";
            msg.ResultMessage = (msg.Data == null) ? "조회된 목록이 없습니다." : "OK";

            return Ok(msg);
        }
        [HttpPost]
        [Route("api/price/insupPrice")]
        public IHttpActionResult InsupPrice(PriceVO price)
        {
            ApiMessage msg = new ApiMessage();
            bool result = dac.InsupPrice(price);
            msg.ResultCode = result ? "S" : "F";
            msg.ResultMessage = result ? "성공적으로 등록되었습니다." : "단가 정보 등록에 실패하였습니다.";
            return Ok(msg);
        }
        [HttpPost]
        [Route("api/price/ImportExcel")]
        public IHttpActionResult ImportExcel(List<PriceVO> priceList)
        {
            ApiMessage msg = new ApiMessage();
            bool result = dac.ImportExcel(priceList);
            msg.ResultCode = result ? "S" : "F";
            msg.ResultMessage = result ? "성공적으로 등록되었습니다." : "단가 정보 등록에 실패하였습니다.";
            return Ok(msg);
        }
        
    }
}
