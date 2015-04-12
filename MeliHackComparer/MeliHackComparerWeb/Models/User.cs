using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeliSample.Models
{

    public class Identification
    {
        public string type { get; set; }
        public object number { get; set; }
    }

    public class Phone
    {
        public string area_code { get; set; }
        public string number { get; set; }
        public string extension { get; set; }
        public bool verified { get; set; }
    }

    public class AlternativePhone
    {
        public string area_code { get; set; }
        public string number { get; set; }
        public string extension { get; set; }
    }

    public class Ratings
    {
        public decimal positive { get; set; }
        public decimal negative { get; set; }
        public decimal neutral { get; set; }
    }

    public class Transactions
    {
        public string period { get; set; }
        public int total { get; set; }
        public int completed { get; set; }
        public int canceled { get; set; }
        public Ratings ratings { get; set; }
    }

    public class SellerReputation
    {
        public object level_id { get; set; }
        public object power_seller_status { get; set; }
        public Transactions transactions { get; set; }
    }

    public class Canceled
    {
        public object total { get; set; }
        public object paid { get; set; }
    }

    public class Unrated
    {
        public object total { get; set; }
        public object paid { get; set; }
    }

    public class NotYetRated
    {
        public object total { get; set; }
        public object paid { get; set; }
        public object units { get; set; }
    }

    public class Transactions2
    {
        public string period { get; set; }
        public object total { get; set; }
        public object completed { get; set; }
        public Canceled canceled { get; set; }
        public Unrated unrated { get; set; }
        public NotYetRated not_yet_rated { get; set; }
    }

    public class BuyerReputation
    {
        public int canceled_transactions { get; set; }
        public Transactions2 transactions { get; set; }
    }

    public class ImmediatePayment
    {
        public bool required { get; set; }
        public List<object> reasons { get; set; }
    }

    public class List
    {
        public bool allow { get; set; }
        public List<string> codes { get; set; }
        public ImmediatePayment immediate_payment { get; set; }
    }

    public class ImmediatePayment2
    {
        public bool required { get; set; }
        public List<object> reasons { get; set; }
    }

    public class Buy
    {
        public bool allow { get; set; }
        public List<object> codes { get; set; }
        public ImmediatePayment2 immediate_payment { get; set; }
    }

    public class ImmediatePayment3
    {
        public bool required { get; set; }
        public List<object> reasons { get; set; }
    }

    public class Sell
    {
        public bool allow { get; set; }
        public List<object> codes { get; set; }
        public ImmediatePayment3 immediate_payment { get; set; }
    }

    public class Billing
    {
        public bool allow { get; set; }
        public List<string> codes { get; set; }
    }

    public class Status
    {
        public string site_status { get; set; }
        public List list { get; set; }
        public Buy buy { get; set; }
        public Sell sell { get; set; }
        public Billing billing { get; set; }
        public bool mercadopago_tc_accepted { get; set; }
        public string mercadopago_account_type { get; set; }
        public string mercadoenvios { get; set; }
        public bool immediate_payment { get; set; }
    }

    public class Credit
    {
        public int consumed { get; set; }
        public string credit_level_id { get; set; }
    }

    public class UserObject
    {
        public int id { get; set; }
        public string nickname { get; set; }
        public string registration_date { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string country_id { get; set; }
        public string email { get; set; }
        public Identification identification { get; set; }
        public Phone phone { get; set; }
        public AlternativePhone alternative_phone { get; set; }
        public string user_type { get; set; }
        public List<string> tags { get; set; }
        public object logo { get; set; }
        public int points { get; set; }
        public string site_id { get; set; }
        public string permalink { get; set; }
        public List<string> shipping_modes { get; set; }
        public object seller_experience { get; set; }
        public SellerReputation seller_reputation { get; set; }
        public BuyerReputation buyer_reputation { get; set; }
        public Status status { get; set; }
        public Credit credit { get; set; }
    }
}