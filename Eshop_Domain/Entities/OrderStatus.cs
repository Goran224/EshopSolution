using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_Domain.Entities
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Payment Recieved")]

        PaymentRecieved,

        [EnumMember(Value = "Payment Failed")]

        PaymentFailed,

        [EnumMember(Value = "Delivered")]

        Delivered

    }

}
