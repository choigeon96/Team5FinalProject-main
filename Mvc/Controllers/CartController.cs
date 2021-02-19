using Mvc.DAC;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index(string returnUrl)
        {
            //세션에서 장바구니정보를 조회해서 목록으로 보여준다.
            //ViewBag.ReturnUrl = returnUrl;
            CartIndexViewModel cartModel = new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            };
            return View(cartModel);
        }

        public ActionResult AddToCart(int productID, string returnUrl)
        {
            //선택된 제품을 세션에 추가
            ProductDAC dac = new ProductDAC();
            Product prod = dac.GetProductInfo(productID);
            Cart cart = GetCart();
            cart.AddItem(prod, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult RemoveFromCart(int ProductID, string returnUrl)
        {
            GetCart().RemoveItem(ProductID);
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(ShipInfo info)
        {
            //배송정보까지 정상적으로 입력받은 경우
            Cart cart = GetCart();
            if (cart.Lines.Count < 1)
            {
                ModelState.AddModelError("", "장바구니가 비었습니다.");
            }
            if (ModelState.IsValid)
            {
                //장바구니의 내용을 DB에 저장
                //배송정보를 Order테이블에 저장, 장바구니의 제품ID, 수량을 OrderDetail에 저장

                //주문완료 메일을 발송
                EmailProcessor email = new EmailProcessor();
                email.ProcessorOrder(info, cart);

                //장바구니 비워주기
                cart.Clear();
            }
            return View();
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}