using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.BaseEntity
{
    public class baseEntity
    {
        [Key]
        public int ID { get; set; }

        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    
        private DateTime? dataCriacao
        {
            get { return DataCriacao; }
            set { DataCriacao = DateTime.Now;}
        }
        private DateTime? dataAtualizacao
        {
            get { return DataAtualizacao; }
            set { DataAtualizacao = DateTime.Now; }
        }

    }
}
