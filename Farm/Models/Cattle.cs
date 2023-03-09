using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Farm.Models
{
    public class Cattle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date and Time")]

        public DateTime DateAndTime { get; set; }

        [Required]
        [Display(Name = "Camp")]

        public string Camp { get; set; }

        [Required]
        [Display(Name = "Breed")]

        public string Breed { get; set; }

        [Required]
        [Display(Name = "Bulls")]

        public int Bulls { get; set; }

        [Required]
        [Display(Name = "Cows")]

        public int Cows { get; set; }

        [Required]
        [Display(Name = "Bull Calf")]

        public int BullCalf { get; set; }

        [Required]
        [Display(Name = "Cow Calf")]

        public int CowCalf { get; set; }

        [Required]
        [Display(Name = "New Calf")]

        public int NewCalf { get; set; }

        [Required]
        [Display(Name = "Missing")]

        public int Missing { get; set; }

        [Required]
        [Display(Name = "Dead")]

        public int Dead { get; set; }

        [Required]
        [Display(Name = "Branded")]

        public bool Branded { get; set; }

        [Required]
        [Display(Name = "Dipped")]

        public bool Dipped { get; set; }

        [Required]
        [Display(Name = "Injected")]

        public bool Injected { get; set; }

        [Required]
        [Display(Name = "Feed")]

        public string Feed { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Feed Price/bag")]

        public double FeedPrice { get; set; }

        [Required]
        [Display(Name = "Times Fed/week")]

        public double FeedQuantity { get; set; }


        [Display(Name = "Notes")]

        public string Notes { get; set; }


        [Display(Name = "Total")]
        public int Total
        {
            get { return Bulls + Cows + BullCalf + CowCalf + NewCalf; }
        }

        // 3kg per 100kg body mass
        public int BullsFeed
        {
            get { return Bulls * 3; }
        }

        public int CowFeed
        {
            get { return Cows * 1; }
        }

        public int CowCalfFeed
        {
            get { return CowCalf * 1; }
        }

        public int BullCalfFeed
        {
            get { return BullCalf * 1; }
        }

        public int NewCalfFeed
        {
            get { return NewCalf * 0; }
        }

        [Display(Name = "Total Kg of Feed")]
        public int FeedTotal
        {
            get { return BullsFeed + CowFeed + BullCalfFeed + CowCalfFeed; }
        }





        [DataType(DataType.Currency)]
        [Display(Name = "Price of Feed per kg")]
        public double PriceOfBagsTotal
        {
            get { return FeedPrice / 50; }
        }

        [DataType(DataType.Currency)]
        [Display(Name = "Price of Feed per Day")]
        public double PriceOfFeedTotal
        {
            get { return PriceOfBagsTotal * FeedTotal; }
        }



        [DataType(DataType.Currency)]
        [Display(Name = "Price of Feed/Week")]

        public double FeedPricePerWeek
        {
            get { return PriceOfFeedTotal * FeedQuantity; }
        }

        [DataType(DataType.Currency)]
        [Display(Name = "Price of Feed/month")]

        public double FeedPricePerMonth
        {
            get { return FeedPricePerWeek * 4; }
        }

       

    }

    
}
