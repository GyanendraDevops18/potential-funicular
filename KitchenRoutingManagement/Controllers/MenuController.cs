using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using KitchenRoutingManagement.Bussiness;
using KitchenRoutingManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace KitchenRoutingManagement.Controllers
{

    [ApiController]
    [Route("api")]
    public class MenuController : ControllerBase
    {
        private string jsonSerialization = "[\n  {\n    \"productid\": \"855e3b06-75fb-420d-a39c-70af8ed0680a\",\n    \"name\": \"Grilled Cranberry Pear Crumble\",\n\t\"code\": \"1054\",\n\t\"imagesrc\": \"https://www.tasteofhome.com/wp-content/uploads/2018/01/Grilled-Cranberry-Pear-Crumble_EXPS_HCK17_186040_B10_18_5b-1.jpg\",\n\t\"imagealt\": \"Grilled Cranberry Pear Crumble\",\n\t\"type\": \"grill\",\n\t\"price\": 3.99,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n  {\n    \"productid\": \"da282d9b-90bf-474b-9851-b3cfe7d553a7\",\n    \"name\": \"Grilled Guacamole\",\n\t\"code\": \"1055\",\n\t\"imagesrc\": \"https://www.tasteofhome.com/wp-content/uploads/2018/01/exps91531_GI163846_D12_17_4b.jpg\",\n\t\"imagealt\": \"Grilled Guacamole\",\n\t\"type\": \"grill\",\n\t\"price\": 1.99,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n  {\n    \"productid\": \"2fe43e96-020e-44ae-8d08-3c4cc63583ee\",\n    \"name\": \"Grilled Apple Tossed Salad\",\n\t\"code\": \"1056\",\n\t\"imagesrc\": \"https://www.tasteofhome.com/wp-content/uploads/2018/01/Grilled-Apple-Tossed-Salad_EXPS_SDAS17_33475_B04_06_4b-2.jpg\",\n\t\"imagealt\": \"Grilled Apple Tossed Salad\",\n\t\"type\": \"grill\",\n\t\"price\": 3.99,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n  {\n    \"productid\": \"0cbfa4b7-7654-4f02-9799-759dbcb86aa9\",\n    \"name\": \"Spicy Grilled Eggplant\",\n\t\"code\": \"1057\",\n\t\"imagesrc\": \"https://www.tasteofhome.com/wp-content/uploads/2018/01/Spicy-Grilled-Eggplant_EXPS_SDAS17_48576_C04_06_4b-2.jpg\",\n\t\"imagealt\": \"Spicy Grilled Eggplant\",\n\t\"type\": \"grill\",\n\t\"price\": 4.49,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n  {\n    \"productid\": \"ed13b868-9539-4a8e-aaff-d4ccff96a269\",\n    \"name\": \"Grilled Angel Food Cake with Strawberries\",\n\t\"code\": \"1059\",\n\t\"imagesrc\": \"https://www.tasteofhome.com/wp-content/uploads/2018/01/exps162471_SD153320B12_10_8b.jpg\",\n\t\"imagealt\": \"Grilled Angel Food Cake with Strawberries\",\n\t\"type\": \"grill\",\n\t\"price\": 4.29,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n  {\n    \"productid\": \"502751e0-4499-4c11-9b30-d266e37f5ff3\",\n    \"name\": \"Caffeine-Free Coca-Cola Zero\",\n\t\"code\": \"1070\",\n\t\"imagesrc\": \"https://www.cokesolutions.com/products/brands/coca-cola-zero/caffeine-free-coca-cola-zero.main-image.252-363.png\",\n\t\"imagealt\": \"Caffeine-Free Coca-Cola Zero\",\n\t\"type\": \"drink\",\n\t\"price\": 1.99,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n  {\n    \"productid\": \"d33ae793-5bae-4e68-b4e8-a1602dbe4b6b\",\n    \"name\": \"Aquarius\",\n\t\"code\": \"1071\",\n\t\"imagesrc\": \"https://www.cokesolutions.com/products/brands/aquarius/aquarius.main-image.252-363.png\",\n\t\"imagealt\": \"Aquarius\",\n\t\"type\": \"drink\",\n\t\"price\": 1.99,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n  {\n    \"productid\": \"01fb316f-06ed-43a8-b09b-a14cdcdeffd2\",\n    \"name\": \"Coca-Cola® Vanilla\",\n\t\"code\": \"1072\",\n\t\"imagesrc\": \"https://www.cokesolutions.com/products/brands/coca-cola/coca-cola-vanilla.main-image.252-363.png\",\n\t\"imagealt\": \"Coca-Cola® Vanilla\",\n\t\"type\": \"drink\",\n\t\"price\": 1.99,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n  {\n    \"productid\": \"67636b0b-1e0e-4c9e-81ce-8fe50717e598\",\n    \"name\": \"Tomato, Basil, and Feta Salad\",\n\t\"code\": \"1080\",\n\t\"imagesrc\": \"https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F692444.jpg&w=596&h=399&c=sc&poi=face&q=85\",\n\t\"imagealt\": \"Tomato, Basil, and Feta Salad\",\n\t\"type\": \"salad\",\n\t\"price\": 3.99,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n  {\n    \"productid\": \"d2a36615-4a56-42d8-9d9d-6d1fc065eec2\",\n    \"name\": \"French fries\",\n\t\"code\": \"1090\",\n\t\"imagesrc\": \"https://upload.wikimedia.org/wikipedia/commons/6/67/Fries_2.jpg\",\n\t\"imagealt\": \"French fries\",\n\t\"type\": \"fries\",\n\t\"price\": 1.99,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n  {\n    \"productid\": \"d2a36615-4a56-42d8-9d9d-6d1fc065eec2\",\n    \"name\": \"Low Carb Rutabaga Fries\",\n\t\"code\": \"1091\",\n\t\"imagesrc\": \"https://www.wholesomeyum.com/wp-content/uploads/2019/08/wholesomeyum-low-carb-rutabaga-fries-recipe-11.jpg\",\n\t\"imagealt\": \"Low Carb Rutabaga Fries\",\n\t\"type\": \"fries\",\n\t\"price\": 1.99,\n\t\"qty\": 1,\n\t\"createddate\": \"01-16-2021\"\n  },\n]";
        
        private readonly ILogger<MenuController> _logger;
        private readonly ICartBussiness ICartBussiness;
        private readonly IKitchentBussines IKitchentBussines;
        private readonly IOrderBussines IOrderBussines;

        private readonly List<MenuItem> _menu = new List<MenuItem>();

        public MenuController(ILogger<MenuController> logger, 
                ICartBussiness _ICartBussiness,
                IKitchentBussines _IKitchentBussines,
                IOrderBussines _IOrderBussines)
        {
            _logger = logger;
            _menu = JsonConvert.DeserializeObject<List<MenuItem>>(jsonSerialization);

            ICartBussiness = _ICartBussiness;
            IKitchentBussines = _IKitchentBussines;
            IOrderBussines = _IOrderBussines;
        }

        #region Menu Details
        /// <summary>
        /// Get Menu Details from N-POS
        /// </summary>
        /// <remarks>
        ///  Sample Request:
        ///  {
        ///     "productid": "855e3b06-75fb-420d-a39c-70af8ed0680a",
        ///     "name": "Grilled Cranberry Pear Crumble",
        ///     "code": "1054",
        ///     "imagesrc": "https://www.tasteofhome.com/wp-content/uploads/2018/01/Grilled-Cranberry-Pear-Crumble_EXPS_HCK17_186040_B10_18_5b-1.jpg",
        ///     "imagealt": "Grilled Cranberry Pear Crumble",
        ///     "type": "grill",
        ///     "price": 3.99,
        ///     "currency": "USD",
        ///     "createddate": "01-16-2021"
        ///  }
        /// </remarks>
        /// <param name="Menu Details"></param>
        /// <returns>
        /// Responce from Service call
        /// </returns>
        /// <response code="200">Success Call</response>
        /// <response code="400">Bad Call</response>
        [HttpGet]
        [Route("product")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<MenuItem>> Get()
        {
            return _menu;
        }
        #endregion

        #region Checkout Details
        [HttpGet]
        [Route("cart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<cartlineitemdetails>> GetCart()
        {
            var result = await Task.Run(() => ICartBussiness.getCartItemCollection());
            return result;
        }

        [HttpPost]
        [Route("cart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] MenuItem _menuItem)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() => ICartBussiness.AddCartItem(_menuItem));
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("cart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put()
        {
            ICartBussiness.checkoutcart();
            return Ok();
        }

        [HttpDelete]
        [Route("cart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetDelete([FromBody] cartdelete _item)
        {
            ICartBussiness.DeleteItem(_item.id.Trim());
            return Ok();
        }
        #endregion

        #region Order Details
        [HttpGet]
        [Route("order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<cartlineitemdetails>> GetOrder()
        {
            var result = await Task.Run(() => IOrderBussines.getOrdersCollection());
            return result;
        }
        #endregion

        #region Kitchent POS Details
        [HttpGet]
        [Route("kitchent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<kitchenlineitems>> GetKitchent()
        {
            var result = await Task.Run(() => IKitchentBussines.getKitchentCollection());
            return result;
        }

        [HttpPatch]
        [Route("kitchent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetDelete([FromBody] cartitemstatus _item)
        {
            string _nextStatus = string.Empty;

            switch (_item.currentstatus.Trim().ToLower())
            {
                case StatusCodeMetadata.Checkout:
                    _nextStatus = StatusCodeMetadata.Prepration;
                    break;
                case StatusCodeMetadata.Prepration:
                    _nextStatus = StatusCodeMetadata.Prepared;
                    break;
                case StatusCodeMetadata.Prepared:
                    _nextStatus = StatusCodeMetadata.Served;
                    break;
            }

            if (!string.IsNullOrEmpty(_nextStatus))
                ICartBussiness.Update(_item.id, _nextStatus, _item.checkincode);

            return Ok();
        }
        #endregion
    }
}