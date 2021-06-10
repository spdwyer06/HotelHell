using HotelHell_Models.Hotel;
using HotelHell_Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HotelHell_Web.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/Hotel")]
    public class HotelController : ApiController
    {
        private async Task<bool> SetStarStateAsync(int hotelId, bool newState)
        {
            if (RequestContext.Principal.IsInRole("Admin"))
            {
                // Do admin stuff
            }

            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HotelService(userId);

            // Get the hotel
            var detail = await service.GetHotelByIdAsync(hotelId);

            // Create the HotelEdit model with new star state
            var updatedHotel = new HotelEdit
            {
                Id = detail.Id,
                Name = detail.Name,
                IsFavorite = newState,
                BuildingNumber = detail.BuildingNumber,
                StreetAddress = detail.StreetAddress,
                City = detail.City,
                State = detail.State,
                ZipCode = detail.ZipCode,
            };

            // Return a value indicating whether the update succeeded
            return await service.UpdateHotelAsync(updatedHotel);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public async Task<bool> ToggleStarOnAsync(int id) => await SetStarStateAsync(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public async Task<bool> ToggleStarOffAsync(int id) => await SetStarStateAsync(id, false);
    }
}
