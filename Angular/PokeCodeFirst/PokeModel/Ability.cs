using System.ComponentModel.DataAnnotations;

namespace PokeModel
{
    public class Ability
    {
        [Key]
        public int AbId { get; set; }
        public string Name { get; set; }

        //Full property is needed to add validation
        private int _PP;
        public int PP
        {
            get { return _PP; }
            //You can only set PP above 0
            set
            {
                if (value > 0)
                {
                    _PP = value;
                }
                else
                {
                    throw new Exception("You cannot set PP lower than 0!");
                }
            }
        }

        public int Power { get; set; }
        public int Accuracy { get; set; }

        public Ability()
        {
            Name = "Tackle";
            PP = 40;
            Power = 40;
            Accuracy = 80;
        }

        public int PokemonPokeId { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            return $"Id: {AbId}\nName: {Name}\nPP: {PP}\nPower: {Power}\nAccuracy: {Accuracy}";
        }
    }
}