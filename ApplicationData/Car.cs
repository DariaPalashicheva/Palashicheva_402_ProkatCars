//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Palashicheva_402_ProkatCars.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.Rent = new HashSet<Rent>();
        }
    
        public int IdCar { get; set; }
        public string Model { get; set; }
        public int BrandID { get; set; }
        public decimal Year { get; set; }
        public int ColorId { get; set; }
        public string Number { get; set; }
        public decimal DayPrice { get; set; }
        public bool Rented { get; set; }
        public string Photo { get; set; }
        public string ImagePath
        {
            get
            {
                return "/Resources/" + Photo;
            }
        }
        public string ModelNumber
        {
            get
            {
                return this.Model + " - " + this.Number;
            }
        }

        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rent> Rent { get; set; }
    }
}
