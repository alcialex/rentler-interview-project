using System.ComponentModel.DataAnnotations;

namespace Rentler.Interview.Api.Entities
{
    public class Food
    {

        public long FoodId { get; set; }

        [MaxLength(100)]
        public string Brand { get; set; } //(max length 100 alphanumeric)
        [MaxLength(250)]
        public string Description { get; set; }//   (max length 250 alphanumeric)
        public int ServingSize { get; set; } //number of grams
        public int Calories { get; set; }   // (int)
        public int Fat { get; set; }//(int) - number of grams
        public int Carbohydrates { get; set; }  //     (int) - number of grams
        public int Protein { get; set; } //(int) - number of grams
        public int Sodium { get; set; } // (int) - number of milligrams
        public int Potassium { get; set; } //   (int) - number of milligrams
        public int Cholesterol { get; set; } // (int) - number of milligrams

    }
}
