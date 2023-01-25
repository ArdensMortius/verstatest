using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace verstatest.Models
{
    public class Order
    {
        [Key]
        public string Order_ID { get; set; }
        [Required]
        public string Customer { get; set; }
        //[Required]        
        public Address DeliveryAddress { get; set; }       
        //[Required]        
        public Address SendersAddress { get; set; }
        [Required]
        public float CargoWeight { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime PickupDate { get; set; }

        public Order()
        {
            Order_ID = Guid.NewGuid().ToString();
            Customer = "";
            DeliveryAddress= new Address();
            SendersAddress = new Address();            
        }

        //public Order (string customer,
        //              //Address? deliveryAddress, 
        //              //Address? sendersAddress, 
        //              float cargoWeight, 
        //              DateTime pickupDate)
        //{
        //    Order_ID = Guid.NewGuid().ToString();
        //    Customer = customer;
        //    //DeliveryAddress = deliveryAddress;
        //    //SendersAddress = sendersAddress;
        //    CargoWeight = cargoWeight;
        //    PickupDate = pickupDate;
        //}
    }
}
