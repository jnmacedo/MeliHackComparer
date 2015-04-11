using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeliSample.Models
{

    public class Product
    {
        public string id { get; set; }
        public string category_level_2 { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public Seller seller { get; set; }
        public double price { get; set; }
        public string currency_id { get; set; }
        public int sold_quantity { get; set; }
        public string buying_mode { get; set; }
        public string listing_type_id { get; set; }
        public string stop_time { get; set; }
        public string condition { get; set; }
        public string permalink { get; set; }
        public string thumbnail { get; set; }
        public bool accepts_mercadopago { get; set; }
        public Installments installments { get; set; }
        public Address address { get; set; }
        public SellerAddress seller_address { get; set; }
        public List<object> attributes { get; set; }

        public override string ToString()
        {
            return string.Format("[RootObject: id={0}, site_id={1}, title={2}, subtitle={3}]", id, site_id, title, subtitle);
        }
    }
    public class Seller
    {
        public int id { get; set; }
        public object power_seller_status { get; set; }
        public bool car_dealer { get; set; }
        public bool real_estate_agency { get; set; }
    }

    public class Installments
    {
        public int quantity { get; set; }
        public double amount { get; set; }
        public string currency_id { get; set; }
    }

    public class Address
    {
        public string state_id { get; set; }
        public string state_name { get; set; }
        public string city_id { get; set; }
        public string city_name { get; set; }
    }

    public class Country
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class State
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class SellerAddress
    {
        public int id { get; set; }
        public string comment { get; set; }
        public string address_line { get; set; }
        public string zip_code { get; set; }
        public Country country { get; set; }
        public State state { get; set; }
        public City city { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}