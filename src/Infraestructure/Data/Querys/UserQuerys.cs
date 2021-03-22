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
        public const string CreateUser = @"insert into Users values (@Id, @Name, @MiddleName, @LastName, @SurName, @UserName, @Password, 
                                         @CreatedOn, @CreatedBy, @ModifiedOn, @ModifiedBy, @State); select * from Users where Id=@Id";
        /// <summary>
        /// Query Update User
        /// </summary>
        public const string UpdateUser = @"UPDATE Users SET Name=@Name, MiddleName=@MiddleName, LastName=@LastName, SurName=@SurName, UserName=@UserName, Password=@Password, 
                                        CreatedOn=@CreatedOn, CreatedBy=@CreatedBy, ModifiedOn=@ModifiedOn, ModifiedBy=ModifiedBy, State=@State WHERE Id=@Id";
        /// <summary>
        /// Query Update State
        /// </summary>
        public const string UpdateStateUser = @"UPDATE Users SET State=@State WHERE Id=@Id";
        /// <summary>
        /// Query Select User
        /// </summary>
        public const string SelectUser = "SELECT Id, Name, MiddleName, LastName, SurName, UserName, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, State FROM Users";

        /// <summary>
        /// Query Select User
        /// </summary>
        public const string SelectUpdatePasswordUser = "SELECT Id, Name, MiddleName, LastName, SurName, UserName, Password, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, State FROM Users" +
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
        public const string SelectLoginUser = "SELECT Id, Name, MiddleName, LastName, SurName, UserName, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, " +
                                              "State FROM Users Where UserName=@UserName AND Password=@Password";
    }
}
