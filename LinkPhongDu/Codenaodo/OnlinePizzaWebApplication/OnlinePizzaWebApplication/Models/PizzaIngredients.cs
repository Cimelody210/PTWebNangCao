using System.ComponentModel;

namespace OnlinePizzaWebApplication.Models
{
    public class PizzaIngredients
    {
        public int Id { get; set; }

        [DisplayName("Chọn Pizza")]
        public int PizzaId { get; set; }

        [DisplayName("Chọn nguyên liệu")]
        public int IngredientId { get; set; }

        public virtual Ingredients Ingredient { get; set; }
        public virtual Pizzas Pizza { get; set; }
    }
}