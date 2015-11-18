using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TownSystem.Services.Data.Contracts;
using TownSystem.Services.Models.Picture;

namespace TownSystem.Services.Controllers
{
    public class PicturesController : ApiController
    {
        private readonly IDropboxService dropbox;
        
        [Authorize]
        public IHttpActionResult Post(PictureDetailsRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return null;
        }
    }
}
