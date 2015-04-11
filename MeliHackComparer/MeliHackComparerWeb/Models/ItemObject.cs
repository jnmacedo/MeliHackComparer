using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeliSample.Models
{

    public class ItemObject
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public int seller_id { get; set; }
        public string category_id { get; set; }
        public int price { get; set; }
        public int base_price { get; set; }
        public string currency_id { get; set; }
        public int initial_quantity { get; set; }
        public int available_quantity { get; set; }
        public int sold_quantity { get; set; }
        public string buying_mode { get; set; }
        public string listing_type_id { get; set; }
        public string start_time { get; set; }
        public string stop_time { get; set; }
        public string condition { get; set; }
        public string permalink { get; set; }
        public string thumbnail { get; set; }
        public List<Picture> pictures { get; set; }
        public object video_id { get; set; }
        public List<Description> descriptions { get; set; }
        public bool accepts_mercadopago { get; set; }
        public List<object> non_mercado_pago_payment_methods { get; set; }
        public Shipping shipping { get; set; }
        public SellerAddress seller_address { get; set; }
        public object seller_contact { get; set; }
        public object location { get; set; }
        public Geolocation geolocation { get; set; }
        public List<object> coverage_areas { get; set; }
        public List<object> attributes { get; set; }
        public List<object> variations { get; set; }
        public string status { get; set; }
        public List<object> sub_status { get; set; }
        public List<object> tags { get; set; }
        public string warranty { get; set; }
        public object catalog_product_id { get; set; }
        public string parent_item_id { get; set; }
        public string date_created { get; set; }
        public string last_updated { get; set; }
    }
}