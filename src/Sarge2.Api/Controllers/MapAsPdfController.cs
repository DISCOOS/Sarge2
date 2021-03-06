﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sarge.Maps;
using System.IO;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sarge2.Api.Controllers
{
    [Route("api/[controller]")]
    public class MapAsPdfController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        //// POST api/values
        //[HttpPost()]
        //public async Task<Guid> Post([FromBody]MapSetup setup)
        //{
        //    if (setup == null)
        //        throw new ArgumentException("Unable to parse MapSetup parameter", "setup");

        //    MapLoader vLoader = new MapLoader(setup);
        //    using (var vBitmap = await vLoader.CreateBitmapForPrintAsync())
        //    {
        //        Guid vFileID = Guid.NewGuid();
        //        string vFilename = Path.Combine(Path.GetTempPath(), vFileID.ToString());
        //        using (var vFile = System.IO.File.Create(vFilename))
        //        {
        //            await vLoader.CreatePDFWithPdfSharpAsync(vBitmap, setup.Title, null, vFile);
        //        }

        //        return vFileID;
        //    }
        //}

        // POST api/values
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]MapSetup setup)
        {
            if (setup == null)
                throw new ArgumentException("Unable to parse MapSetup parameter", "setup");

            MapLoader vLoader = new MapLoader(setup);
            using (var vBitmap = await vLoader.CreateBitmapForPrintAsync())
            {
                Guid vFileID = Guid.NewGuid();
                string vFilename = Path.Combine(Path.GetTempPath(), vFileID.ToString());
                using (var vFile = System.IO.File.Create(vFilename))
                {
                    await vLoader.CreatePDFWithPdfSharpAsync(vBitmap, setup.Title, null, vFile);
                }

                return File(System.IO.File.ReadAllBytes(vFilename), "application/pdf");
            }
        }

        [HttpGet("{file}")]
        public FileStreamResult GetMap(Guid file)
        {
            string vFilename = Path.Combine(Path.GetTempPath(), file.ToString());
            var vFile = System.IO.File.OpenRead(vFilename);
            Response.Headers.Add("Content-Disposition", "attachment;filename=Kart.pdf");
            return new FileStreamResult(vFile, "application/pdf");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
