

public static class VGlobal 
{
    static string conexion ="Data Source=DerekGA;Initial Catalog=ClubDeportivo;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
   // static string conexion1 = "Data Source=DerekGA;Initial Catalog=ClubDeportivo;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
    //static string conexion2 = "Data Source=DerekGA;Initial Catalog=ClubDeportivo;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";


    public static string getSetConexion 
    {
        get
        {
            return conexion;
        }
        set 
        { 
            conexion = value;
        }
    }
}