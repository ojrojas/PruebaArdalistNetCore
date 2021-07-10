namespace Application.Data
{
    public static class QueryTypeIdentification
    {
        public const string GetTypeIdentificacion = "SELECT Id, Description, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, State FROM TypeIdentifications WHERE Id=@Id";
        public const string GetAllTypeIdentification = "SELECT Id, Description, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, State FROM TypeIdentifications";
        public const string InsertTypeIdentification = @"INSERT INTO TypeIdentifications(Id, Description, CreatedOn, CreatedBy, State)
                                    VALUES(@Id, @Description, @CreatedOn, @CreatedBy, @State);" + GetTypeIdentificacion;



    }
}
