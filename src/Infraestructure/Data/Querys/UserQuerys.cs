namespace Application.Data
{
    /// <summary>
    /// UserQuerys database 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public static class UserQuerys
    {
        /// <summary>
        /// Query Create User
        /// </summary>
        public const string CreateUser = @"INSERT INTO Users
                                        (Id, CreatedBy, CreatedOn, Email, Identification, IdentificationType, LastName, MiddleName, 
                                        ModifiedBy, ModifiedOn, Name, Password, State, SurName)
                                        VALUES(@Id, @CreatedBy, @CreatedOn, @Email, @Identification, 
                                        @IdentificationType, @LastName, @MiddleName, @ModifiedBy, 
                                        @ModifiedOn, @Name, @Password, @State, @SurName); select * from Users where Id=@Id";
        /// <summary>
        /// Query Update User
        /// </summary>
        public const string UpdateUser = @"UPDATE Users SET Name=@Name, MiddleName=@MiddleName, LastName=@LastName, SurName=@SurName, Email=@Email, Password=@Password, 
                                        CreatedOn=@CreatedOn, CreatedBy=@CreatedBy, ModifiedOn=@ModifiedOn, ModifiedBy=ModifiedBy, State=@State, 
                                        Identification=@Identification, IdentificationType=@IdentificationType  WHERE Id=@Id";
        /// <summary>
        /// Query Update State
        /// </summary>
        public const string UpdateStateUser = @"UPDATE Users SET State=@State WHERE Id=@Id";
        /// <summary>
        /// Query Select User
        /// </summary>
        public const string SelectUser = "SELECT Id, Name, MiddleName, LastName, SurName, Email, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, State, identification, identificationType FROM Users";

        /// <summary>
        /// Query Select User
        /// </summary>
        public const string SelectUpdatePasswordUser = "SELECT Id, Name, MiddleName, LastName, SurName, Email, Password, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, State,, identification, identificationType FROM Users" +
                                                     "Where Id=@Id AND Password=@Password";

        /// <summary>
        /// Query Select User
        /// </summary>
        public const string UpdatePasswordUser = "UPDATE set Password=@Password" +
                                                     " Where Id=@Id";

        /// <summary>
        /// Query Delete User
        /// </summary>
        public const string DeleteUser = "DELETE FROM Users Where Id=@Id";
        /// <summary>
        /// Query Select Login
        /// </summary>
        public const string SelectLoginUser = "SELECT Id, Name, MiddleName, LastName, SurName, Email, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, " +
                                              "State FROM Users Where Email=@Email AND Password=@Password";
    }
}
