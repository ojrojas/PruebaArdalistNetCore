namespace Data.Querys
{
    public static class CardFailsQuerys
    {
        public const string SelectCardFilsById = @"SELECT Id, Quantities, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, State FROM CardFails Where Id=@Id;";
        public const string InsertarCardFails = @"INSERT INTO CardFails 
        (Id, Quantities, CreatedOn, CreatedBy, State) VALUES(@Id, @Quantities, @CreatedOn, @CreatedBy, @State);" + SelectCardFilsById;

        
    }
}
