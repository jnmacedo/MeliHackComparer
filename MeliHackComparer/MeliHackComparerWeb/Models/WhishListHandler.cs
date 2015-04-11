using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeliSample.Models
{
    public class WhishListHandler
    {
        MeliService ms;

        private List<Product> _whishList = new List<Product>();

        /// <summary>
        /// Get all the items in the wish list
        /// </summary>
        /// <returns>una lista de productos con los elementos marcados como deseados</returns>
        public List<Product> WhishList()
        {
            if (_whishList == null)
                _whishList = new List<Product>();
            return _whishList;
        }

        public List<Product> WhishList(string categoryId)
        {
            foreach (Product item in _whishList)
            {
                if(string.IsNullOrEmpty(item.category_level_2))
                {
                    item.category_level_2 = GetCategoryLevel2(item.id);
                }
            }
            return null;
        }

        private string GetCategoryLevel2(string itemId)
        {
            return ms.GetProduct(itemId).category_id;
        }

        /// <summary>
        /// Agregar producto a la lista de deseados
        /// </summary>
        /// <param name="p">es de tipo Product.</param>
        public void AddProductToWhishList(Product p)
        {
            _whishList.Add(p);
        }

        /// <summary>
        /// Eliminar un producto determinado de la lista de deaeados.
        /// </summary>
        /// <param name="productId">Id del producto a eliminar de la lista.</param>
        public void RemoveProductFromWhishList(string productId)
        {
            int i = 0;
            while (i < _whishList.Count)
            {
                if (_whishList[i].id == productId)
                    _whishList.RemoveAt(i);
                else
                    i++;
            }
        }

        public List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            foreach (Product item in _whishList)
            {
                if (string.IsNullOrEmpty(item.category_level_2))
                {
                    item.category_level_2 = GetCategoryLevel2(item.id);
                }
                if (!categories.Contains(item.category_level_2))
                {
                    categories.Add(item.category_level_2);
                }
            }
            return categories;
        }

        public Dictionary<string,string> GetComparableAttributesList(Product p1)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            foreach (object attr1 in p1.attributes)
            {
                switch (attr1.ToString())
                {
                    default: attributes.Add(attr1.ToString(), attr1.ToString()); break;
                }

            }
            return attributes;
        }
    }
}