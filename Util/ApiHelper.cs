using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VO;
namespace Util
{
    public class ApiHelper : AccessUrl, IDisposable
    {
        HttpClient client = new HttpClient();

        public string BaseServiceUrl { get; set; }

        public ApiHelper()
        {
            BaseServiceUrl = BaseUrl;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ApiHelper(string routePrefix)
        {
            BaseServiceUrl = $"{ConfigurationManager.AppSettings["ApiAddress"]}/{routePrefix}";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// GET 실행 후 ApiMessage<T> 반환
        /// </summary>
        /// <typeparam name="T">VO형식</typeparam>
        /// <param name="path">API호출 URL - BaseServiceUrl을 제외한 상세주소만 파라미터로 전달</param>
        /// <returns>ApiMessage<T></returns>
        public ApiMessage<T> GetApiCaller<T>(string path)
        {
            path = BaseServiceUrl + path;

            ApiMessage<T> msg = null;
            try
            {
                using (Task<HttpResponseMessage> response = client.GetAsync(path))
                {
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsAsync<ApiMessage<T>>();
                        result.Wait();

                        msg = result.Result;
                    }
                }
                return msg;
            }
            catch(Exception err)
            {
                return msg;
            }
        }

        /// <summary>
        /// GET 실행 후 ApiMessage 반환
        /// </summary>
        /// <param name="path">API호출 URL - BaseServiceUrl을 제외한 상세주소만 파라미터로 전달</param>
        /// <returns>ApiMessage</returns>
        public ApiMessage GetApiCallerNone(string path)
        {
            path = BaseServiceUrl + path;

            ApiMessage msg = null;
            try
            {
                using (Task<HttpResponseMessage> response = client.GetAsync(path))
                {
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsAsync<ApiMessage>();
                        result.Wait();

                        msg = result.Result;
                    }
                }
                return msg;
            }
            catch
            {
                return msg;
            }
        }


        /// <summary>
        /// POST 실행 후 결과(성공여부, 메세지, VO) 반환 
        /// </summary>
        /// <typeparam name="T">VO 형식</typeparam>
        /// <param name="path">API호출 URL - BaseServiceUrl을 제외한 상세주소만 파라미터로 전달</param>
        /// <param name="t">Request로 전달할 VO</param>
        /// <returns>ApiMessage<T></returns>
        public ApiMessage<T> PostApiCaller<T>(string path, T t)
        {
            path = BaseServiceUrl + path;

            ApiMessage<T> msg = null;
            try
            {
                using (Task<HttpResponseMessage> response = client.PostAsJsonAsync(path, t))
                {
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsAsync<ApiMessage<T>>();
                        result.Wait();

                        msg = result.Result;
                    }
                }
                return msg;
            }
            catch
            {
                return msg;
            }
        }

        /// <summary>
        /// Request객체를 POST 방식으로 API호출하여 Response객체를 반환
        /// </summary>
        /// <typeparam name="T">Response타입</typeparam>
        /// <typeparam name="K">Request타입</typeparam>
        /// <param name="path">API호출 URL - BaseServiceUrl을 제외한 상세주소만 파라미터로 전달</param>
        /// <param name="k">Request객체</param>
        /// <returns></returns>
        public ApiMessage<T> PostApiCaller<T, K>(string path, K k) where T : class
        {
            path = BaseServiceUrl + path;

            ApiMessage<T> msg = null;
            try
            {
                using (Task<HttpResponseMessage> response = client.PostAsJsonAsync(path, k))
                {
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsAsync<ApiMessage<T>>();
                        result.Wait();

                        msg = result.Result;
                    }
                }
                return msg;
            }
            catch
            {
                return msg;
            }
        }

        /// <summary>
        /// POST 실행 후 결과(성공여부, 메세지)만 반환 
        /// </summary>
        /// <typeparam name="T">VO 형식</typeparam>
        /// <param name="path">API호출 URL - BaseServiceUrl을 제외한 상세주소만 파라미터로 전달</param>
        /// <param name="t">Request로 전달할 VO</param>
        /// <returns>ApiMessage</returns>
        public ApiMessage PostApiCallerNone<T>(string path, T t)
        {
            path = BaseServiceUrl + path;

            ApiMessage msg = null;
            try
            {                
                using (Task<HttpResponseMessage> response = client.PostAsJsonAsync(path, t))
                {
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var result = response.Result.Content.ReadAsAsync<ApiMessage>();
                        result.Wait();

                        msg = result.Result;
                    }
                }
                return msg;
            }
            catch
            {
                return msg;
            }
        }


        public void Dispose()
        {
            client.Dispose();
        }
    }
}
