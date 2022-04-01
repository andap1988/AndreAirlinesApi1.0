using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndreAirlinesApi.Model
{
    public class Passenger
    {
        #region Properties

        public int Id { get; set; }
        public string Cpf { get; set; }
        [Column("Nome", TypeName = "varchar(50)")]
        public string Name { get; set; }
        public string Telephone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateBirth { get; set; }
        public string Email { get; set; }
        public virtual Address Address { get; set; }

        #endregion
    }
}
