using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WS_TexasSales.Models;
using WS_TexasSales.Models.Request;
using WS_TexasSales.Models.Response;

namespace WS_TexasSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrademarkController : ControllerBase
    {
        [Route("getarray")]
        [HttpGet]
        public IActionResult GetArrayById([FromBody] List<int> Id) 
        {
            using (var dbContext = new Models.texas_salesdbContext()) 
            {
                var lst = from db in dbContext.Trademark.ToList()
                          where Id.Contains(db.TmId)
                          select new TrademarkVM 
                          { 
                              TmId = db.TmId,
                              TmName = db.TmName
                          };
                return Ok(lst);
            }
        }

        public class TrademarkVM
        {
            public int TmId { get; set; }
            public string TmName { get; set; }
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response oResponse = new Response();

            try
            {
                using (texas_salesdbContext db = new texas_salesdbContext())
                {
                    var lst = db.Trademark.OrderByDescending(d => d.TmId).ToList();
                    oResponse.Success = true;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPost]
        public IActionResult Add(Trademark_Request oTrademarkRequest )
        {
            Response oResponse = new Response();

            try 
            {
                using ( texas_salesdbContext db = new texas_salesdbContext()) 
                {
                    Trademark oTrademark = new Trademark();
                    oTrademark.TmName = oTrademarkRequest.TmName;
                    db.Add(oTrademark);
                    db.SaveChanges();

                    oResponse.Success = true;
                }
            } 
            catch ( Exception ex) 
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPut]
        public IActionResult Edit(Trademark_Request oTrademarkRequest)
        {
            Response oResponse = new Response();

            try 
            {
                using (texas_salesdbContext db = new texas_salesdbContext())
                {
                    Trademark oTrademark = db.Trademark.Find(oTrademarkRequest.TmId);
                    oTrademark.TmName = oTrademarkRequest.TmName;
                    db.Entry(oTrademark).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    oResponse.Success = true;                
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);
        }

        [HttpDelete("{tmid}")]
        public IActionResult Delete(int tmid) 
        {
            Response oResponse = new Response();

            try
            {
                using (texas_salesdbContext db = new texas_salesdbContext()) 
                {
                    Trademark oTrademark = db.Trademark.Find(tmid);
                    db.Remove(oTrademark);
                    db.SaveChanges();

                    oResponse.Success = true;
                }
            }
            catch(Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }
    }
}
