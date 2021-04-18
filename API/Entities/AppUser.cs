namespace API.Entities
{
    //koristi bilo sta osim usera da ne bi bilo zabune, zato je AppUser
    public class AppUser
    {
        public int Id { get; set; }

        //UserName (N je veliko) da ne bi bilo zabune u programu, tj da ne bismo imali vise posla oko refaktorisanja
        public string UserName { get; set; }

        
    }
}