using API.DAC;
using API.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace API.Controllers
{
    //API에서 쓰이는 DAC과 VO파일은 참조추가하지않고
    //API프로젝트내의 DAC폴더와 Models폴더에 추가해서 사용한다.
    //VO는 Models파일에
    
    //[RoutePrefix("api/Sample")] //RoutePrefix를 추가하면  api/Sample/{id} => {id} 로 줄일 수 있다.
    public class SampleController : ApiController
    {
        //로그 선언
        //ILog log = log4net.LogManager.GetLogger(typeof(SampleController));

        private void WriteLog()
        {
            //log.Debug("로그 작성");
        }


        // GET: api/Sample
        [Route("api/Sample")]
        public List<SampleVO> Get()
        {
            SampleDAC dac = new SampleDAC();
            return dac.GetSample();
        }

        // GET: api/Sample/5
        // Example : https://localhost:44384/api/Sample/5 

        [Route("api/Sample/{id}")] //Url경로 지정 (이 Get 함수를 호출하려면 해당 URL로 접속해야함)
        public SampleVO Get(int id)
        {
            SampleDAC dac = new SampleDAC();
            return dac.GetSample()[id];
        }


        // POST: api/Sample
        //{sampleID = "", name = "" , value1=""}
        //메시지만 반환
        [HttpPost]
        public HttpResponseMessage Post([FromBody]SampleVO value)
        {
            //DAC단에서 추가 메서드 실행후 결과에 따라 HttpResponseMessage형식으로 반환
            int a = 1;
            if (a == 1)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value.Name);
                response.Content = new StringContent($"메시지 입력", System.Text.Encoding.Unicode);

                return response;
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }

        }

        // POST: api/Sample
        //추가 후 값 전달
        [HttpPost]
        public IHttpActionResult Post([FromBody]string value)
        {
            //DAC단에서 추가 메서드 실행후 결과에 따라 IHttpActionResult형식으로 반환
            int a = 1;
            if (a == 1)
            {
                return Ok(new List<SampleVO>());  //ApiController 에서 redirected()등 여러 반환값 필요한걸로 리턴
            }
            else
            {
                return NotFound();
            }

        }

        // PUT: api/Sample/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
            //수정 매서드 실행 후 반환은 위와동일
        }


        // DELETE: api/Sample/5
        [HttpGet]
        [Route("api/Sampler/5")] //Get방식으로 받아 Delete매서드 실행
        public void Delete(int id)
        {
            //삭제 매서드 실행 후 반환은 위와동일
        }
    }
}
