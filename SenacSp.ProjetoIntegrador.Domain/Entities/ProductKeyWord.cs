using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class ProductKeyWord
    {
        public Product Product { get; private set; }
        public Guid ProductId { get; private set; }
        public KeyWord KeyWord { get; private set; }
        public Guid KeyWordId { get; private set; }

        public static ProductKeyWord New(Guid productId, Guid keyWordId) => new ProductKeyWord
        {
            KeyWordId = keyWordId,
            ProductId = productId
        };

    }
}
