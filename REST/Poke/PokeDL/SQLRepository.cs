using System.Data.SqlClient;
using PokeModel;

namespace PokeDL
{
  public class SQLRepository : IRepository
  {
    //SQLRepository now requires you to provide a connectionString to an existing database to create an object
    //It will also allow SQLRepository to dynamically point to different databases as long as you have the connectionString on it
    private readonly string _connectionString;
    public SQLRepository(string p_connectionString)
    {
      _connectionString = p_connectionString;
    }

    public Pokemon AddPokemon(Pokemon p_poke)
    {
      //@ before the string will ignore sprcial characters like \n
      //This is where you specify the sql statement required to do whatever operation you need based on the method
      string _sqlQuery = @"INSERT INTO Pokemon
                          VALUES (@pokeName, @pokeLevel, @pokeAttack, @pokeDefense, @pokeHealth)";

      //using block is different from our normal using statement 
      //It is used to automatically close any resource you stated inside of the parenthesis
      //If an exception occurs, it will still automatically close any resources
      using (SqlConnection conn = new SqlConnection(_connectionString))
      {
        //Opnes the connection to the database
        conn.Open();

        //SqlCommand class is a class specialized in executing SQL statements
        //Command will how the sqlQuery that will execute on the currently connection we have in the con object 
        SqlCommand _command = new SqlCommand(_sqlQuery, conn);
        _command.Parameters.AddWithValue("@pokeName", p_poke.Name);
        _command.Parameters.AddWithValue("@pokeLevel", p_poke.Level);
        _command.Parameters.AddWithValue("@pokeAttack", p_poke.Attack);
        _command.Parameters.AddWithValue("@pokeDefense", p_poke.Defense);
        _command.Parameters.AddWithValue("@pokeHealth", p_poke.Health);

        //Executes the SQL statement
        _command.ExecuteNonQuery();
      }

      return p_poke;
    }

    public List<Ability> GetAbilitiesByPokeId(int p_pokeId)
    {
      List<Ability> listOfAbility = new List<Ability>();

      string sqlQuery = @"select a.abId ,a.abName , a.abPP , a.abPower , a.abAccuracy from Pokemon p 
                            inner join Pokemon_abilities pa on p.pokeId = pa.pokeId 
                            inner join Ability a on a.abId = pa.abId 
                            where p.pokeId = @pokeId";

      using (SqlConnection con = new SqlConnection(_connectionString))
      {
        con.Open();

        SqlCommand command = new SqlCommand(sqlQuery, con);
        command.Parameters.AddWithValue("@pokeId", p_pokeId);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfAbility.Add(new Ability()
          {
            //Reader column is NOT based on table structure but based on what your select query statement is displaying
            AbId = reader.GetInt32(0),
            Name = reader.GetString(1),
            PP = reader.GetInt32(2),
            Power = reader.GetInt32(3),
            Accuracy = reader.GetInt32(4)
          });
        }
      }
      return listOfAbility;
    }

    public List<Pokemon> GetAllPokemon()
    {
      List<Pokemon> listOfPokemon = new List<Pokemon>();

      string sqlQuery = @"select * from Pokemon";

      using (SqlConnection con = new SqlConnection(_connectionString))
      {
        //Opens connection to the database
        con.Open();

        //Create command object that has our sqlQuery and con object
        SqlCommand command = new SqlCommand(sqlQuery, con);

        //SqlDataReader is a class specialized in reading outputs that came from a sql statement
        //Usually this outputs are in a form of a table and keep that in mind
        SqlDataReader reader = command.ExecuteReader();

        //Read() methods checks if you have more rows to go through
        //If there is another row = true, if not = false
        while (reader.Read())
        {
          listOfPokemon.Add(new Pokemon()
          {
            //Zero-based column index
            PokeId = reader.GetInt32(0), //It will get column PokeId since that is the very first column of our select statement
            Name = reader.GetString(1), //it will get the pokeName column since it is the second column of our select statement
            Level = reader.GetInt32(2),
            Attack = reader.GetInt32(3),
            Defense = reader.GetInt32(4),
            Health = reader.GetInt32(5),
            Abilities = GetAbilitiesByPokeId(reader.GetInt32(0))
          });
        }
      }

      return listOfPokemon;
    }
  }
}