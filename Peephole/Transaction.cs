//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Peephole
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public long FromAccount { get; set; }
        public long ToAccount { get; set; }
        public System.DateTime Timestamp { get; set; }
    
        public virtual BankAccount BankAccount { get; set; }
        public virtual BankAccount BankAccount1 { get; set; }
    }
}
