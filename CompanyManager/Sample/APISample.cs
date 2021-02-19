using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using VO;


namespace CompanyManager
{
    public class APISample
    {
        HttpClient client = new HttpClient();

        //SampleController에 요청할거여서 문자열 Sample 추가
        string url = ConfigurationManager.AppSettings["APIUrl"] + "Sample";  


        // url : https://localhost:44384/api/Sample
        // or
        // url : https://localhost:44384/api/Sample/'요청할 값'
        public async Task<List<SampleVO>> Get_API()
        {
            //해당 url로 요청을 보내고 받은 값을 HttpResponseMessage형식으로 받음
            HttpResponseMessage rm = await client.GetAsync(url);

            //요청이 성공적으로 완료되었으면
            if (rm.IsSuccessStatusCode)
            {
                //요청받은 값을 string 형태로 받아옴
                //[{"Sample":"값1","Value1":"값1"}, {"Sample":"값2","Value1":"값2"} ... ] 
                string result = await rm.Content.ReadAsStringAsync();

                //문자열로 전달받은 값을 JavaScriptSerializer를 이용해 List<SampleVO>형식으로 역직렬화
                JavaScriptSerializer jss = new JavaScriptSerializer();
                List<SampleVO> list = jss.Deserialize<List<SampleVO>>(result);

                return list;
            }
            else
            {
                return new List<SampleVO>();
            }
        }



        // url : https://localhost:44384/api/Sample
        //매개변수 => 등록할 값
        public async Task<string> Post_API(SampleVO sample) 
        {
            //해당 url로 Post요청(+등록할 값)을 보내고 받은 값을 HttpResponseMessage형식으로 받음
            //PostAsJsonAsync메서드 사용하려면 (nuget에서 webapi 참조추가 필요)
            HttpResponseMessage rm = await client.PostAsJsonAsync(url, sample);

            if (rm.StatusCode == System.Net.HttpStatusCode.Created) //요기서 비교할 값은 API에서 리턴할때 보내준 값으로 비교
            {
                string result = await rm.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                return "XX";
            }
        }


        // url : https://localhost:44384/api/Sample/ + SampleID
        public async Task<List<SampleVO>> Put_API(SampleVO sample)
        {
            //수정할 SampleVO의 ID를 추가로 url에 추가
            //이렇게 해야 API의 Put메서드로 넘어감
            string putUrl = $"{url}/{sample.SampleID}";

            //Put.AsJsonAsync 함수를 이용해 putUrl로 SampleVO값을 넘겨서 수정
            HttpResponseMessage rm = await client.PutAsJsonAsync(putUrl, sample);

            if (rm.StatusCode == HttpStatusCode.OK)
            {
                //역직렬화 과정은 Post와 같음
                string result = await rm.Content.ReadAsStringAsync();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                List<SampleVO> list = jss.Deserialize<List<SampleVO>>(result);

                return list;
            }
            else
            {
                return new List<SampleVO>();
            }
        }

        // url : https://localhost:44384/api/Sample/ + SampleID
        public async Task<List<SampleVO>> Delete_API(SampleVO sample)
        {
            //삭제할 SampleVO의 SampleID를 url에 추가
            string delUrl = $"{url}/{sample.SampleID}";

            //Put.AsJsonAsync 함수를 이용해 putUrl로 SampleVO값을 넘겨서 수정
            HttpResponseMessage rm = await client.DeleteAsync(delUrl);

            if (rm.StatusCode == HttpStatusCode.OK)
            {
                //역직렬화 과정은 Post와 같음
                string result = await rm.Content.ReadAsStringAsync();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                List<SampleVO> list = jss.Deserialize<List<SampleVO>>(result);

                return list;
            }
            else
            {
                return new List<SampleVO>();
            }
        }
    }
}
