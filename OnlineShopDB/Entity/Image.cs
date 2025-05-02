using Core.Entity;
using Core.Entity.BaseEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Image : BaseEntity
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; } // Массив байтов для хранения изображения
        public string ContentType { get; set; } // MIME-тип изображения (например, image/jpeg)
        public Guid ProductId { get; set; } // Внешний ключ для связи с товаром
        public Product Product { get; set; } // Навигационное свойство
    }
}
