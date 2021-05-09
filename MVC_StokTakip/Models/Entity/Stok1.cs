//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_StokTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Stok1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stok1()
        {
            this.GirisCikis1 = new HashSet<GirisCikis1>();
        }
    
        public int ID { get; set; }
        [Required(ErrorMessage = "StokAdi alan� bo� ge�ilemez.")]
        public string StokAdi { get; set; }
        public Nullable<decimal> StokMiktar { get; set; }
        [Required(ErrorMessage = "StokBirim alan� bo� ge�ilemez.")]
        public string StokBirim { get; set; }
        [Required(ErrorMessage = "KDV alan� bo� ge�ilemez.")]
        [Range(0,100,ErrorMessage ="0-100 aras� deger giriniz.")]
        [Display(Name ="K.D.V")]
        public int? KDV { get; set; }
        [Required(ErrorMessage = "Fiyat alan� bo� ge�ilemez.")]
        public decimal? Fiyat { get; set; }
        [Required(ErrorMessage = "Aciklama alan� bo� ge�ilemez.")]
        [Display(Name = "A��klama")]
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public Nullable<int> DepoID { get; set; }
        [Required(ErrorMessage = "Tarih alan� bo� ge�ilemez.")]
        [DataType(DataType.Date)]
        public System.DateTime KayitTarih { get; set; }
        [Required(ErrorMessage = "Kullan�c� alan� bo� ge�ilemez.")]
        public int? KullaniciID { get; set; }
    
        public virtual Depo1 Depo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GirisCikis1> GirisCikis1 { get; set; }
        public virtual Kullanici1 Kullanici1 { get; set; }
    }
}