using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApplication5.src.models{
    public class tickets{
        public int id {get; set;}
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime dateEvent { get; set; }
        public string description {get;set;}
        public string status {get;set;}
        public string locateEvent {get;set;}
        public int Price{get;set;}
        public tickets(){
            this.dateEvent = DateTime.Now;
            this.description = "";
            this.status = "";
            this.locateEvent = "";
            this.Price = 0;
        }
    }
}