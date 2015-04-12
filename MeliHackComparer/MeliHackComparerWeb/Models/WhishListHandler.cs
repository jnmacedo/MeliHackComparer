using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeliSample.Models
{
    public class WhishListHandler
    {
        private MeliService ms;

        public WhishListHandler()
        {
            ms = MeliService.GetService();
        }
        private List<ItemObject> _whishList = new List<ItemObject>();

        /// <summary>
        /// Get all the items in the wish list
        /// </summary>
        /// <returns>una lista de productos con los elementos marcados como deseados</returns>
        public List<ItemObject> WhishList()
        {
            if (_whishList == null)
                _whishList = new List<ItemObject>();
            return _whishList;
        }

        public ItemObject GetItemByID(string itemID)
        {
            return _whishList.Where(a => a.id == itemID).FirstOrDefault();
        }

        public List<ItemObject> WhishList(string categoryId)
        {
            List<ItemObject> ret = new List<ItemObject>();
            foreach (ItemObject item in _whishList)
            {
                if (item.BelongsToCategory(categoryId))
                    ret.Add(item);
            }
            return ret;
        }

        public string GetCategoryLevel2(string itemId)
        {
            return ms.GetProduct(itemId).category_id;
        }

        /// <summary>
        /// Agregar producto a la lista de deseados
        /// </summary>
        /// <param name="p">es de tipo Product.</param>
        public void AddProductToWhishList(ItemObject p)
        {
            _whishList.Add(p);
        }

        /// <summary>
        /// Agregar producto a la lista de deseados
        /// </summary>
        /// <param name="productID">Id del producto.</param>
        public void AddProductToWhishList(string productID)
        {
            ItemObject item = ms.GetProduct(productID);
            _whishList.Add(item);
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

        public List<string> GetProductIdList()
        {
            List<string> products = new List<string>();
            foreach (ItemObject item in _whishList)
            {
                products.Add(item.id);
            }
            return products;
        }

        public bool IsProductInWishList(string productId)
        {
            bool pertenece = false;
            int i=0;
            while (!pertenece && i < _whishList.Count)
            {
                pertenece = _whishList[i].id == productId;
                i++;
            }
            return pertenece;
        }

        public List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            foreach (ItemObject item in _whishList)
            {
                if (!categories.Contains(item.category_id))
                {
                    categories.Add(item.category_id);
                }
            }
            return categories;
        }

        public Dictionary<string,string> GetComparableAttributesDictionary(ItemObject p1,string category)
        {
            Dictionary<string, string> dicAttributes = new Dictionary<string, string>();
           
            foreach (object attr1 in p1.attributes)
            {
                Attributes attribute = JsonConvert.DeserializeObject<Attributes>(attr1.ToString());
                if (IsComparableAttribute(attribute.name,category))
                {
                    dicAttributes.Add(attribute.name, attribute.value_name);
                }
            }
            return dicAttributes;
        }

        private bool IsComparableAttribute(string attrName,string category)
        {
            if (category == "MLU1744")
            {
                if (attrName == "Marca" ||
                    attrName == "Modelo" ||
                    attrName == "Combustible" ||
                    attrName == "Cant Puertas" ||
                    attrName == "Kilómetros" ||
                    attrName == "Año" ||
                    attrName == "ABS" ||
                    attrName == "Dirección" ||
                    attrName == "Airbag Conductor" ||
                    attrName == "Airbag Pasajero" ||
                    attrName == "Airbags Laterales" ||
                    attrName == "Aire Acondicionado" ||
                    attrName == "Alarma" ||
                    attrName == "Bloqueo central" ||
                    attrName == "Color" ||
                    attrName == "Unico dueño" ||
                    attrName == "Transmisión" ||
                    attrName == "Cristales electricos")
                {
                    return true;
                }
            }
            else if (category == "MLU1468")
            {
                if ( attrName == "Inmueble"||
                     attrName == "Ambientes"||
                     attrName == "Dormitorios"||
                     attrName == "Cocina"||
                     attrName == "Baños"||
                     attrName == "Estufa a leña"||
                     attrName == "Parrillero"||
                     attrName == "Terraza"||
                     attrName == "Comedor"||
                     attrName == "Dormitorio en suite"||
                     attrName == "Entrepiso"||
                     attrName == "Living comedor"||
                     attrName == "Living"||
                     attrName == "Patio"||
                     attrName == "Sótano"||
                     attrName == "Calefacción"||
                     attrName == "Estado"||
                     attrName == "Garage"||
                     attrName == "Lugar"||
                     attrName == "Superficie del terreno (m²)"||
                     attrName == "Superficie construida (m²)"||
                     attrName == "Antigüedad")
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> GetAttributesList(string category)
        {
            List<string> attributes = new List<string>();
            if (category == "MLU1744")
            {
                attributes.Add("Marca");
                attributes.Add("Modelo");
                attributes.Add("Combustible");
                attributes.Add("Cant Puertas");
                attributes.Add("Kilómetros");
                attributes.Add("Año");
                attributes.Add("ABS");
                attributes.Add("Dirección");
                attributes.Add("Airbag Conductor");
                attributes.Add("Airbag Pasajero");
                attributes.Add("Airbags Laterales");
                attributes.Add("Aire Acondicionado");
                attributes.Add("Alarma");
                attributes.Add("Bloqueo central");
                attributes.Add("Color");
                attributes.Add("Unico dueño");
                attributes.Add("Transmisión");
                attributes.Add("Cristales electricos");
            }
            else if (category == "MLU1468")
            {
                attributes.Add("Inmueble");
                attributes.Add("Ambientes");
                attributes.Add("Dormitorios");
                attributes.Add("Cocina");
                attributes.Add("Baños");
                attributes.Add("Estufa a leña");
                attributes.Add("Parrillero");
                attributes.Add("Terraza");
                attributes.Add("Comedor");
                attributes.Add("Dormitorio en suite");
                attributes.Add("Entrepiso");
                attributes.Add("Living comedor");
                attributes.Add("Living");
                attributes.Add("Patio");
                attributes.Add("Sótano");
                attributes.Add("Calefacción");
                attributes.Add("Estado");
                attributes.Add("Garage");
                attributes.Add("Lugar");
                attributes.Add("Superficie del terreno (m²)");
                attributes.Add("Superficie construida (m²)");
                attributes.Add("Antigüedad");
            }
            return attributes;
        }
    }
}