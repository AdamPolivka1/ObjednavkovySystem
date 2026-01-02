using Orderis.Services.Auth;

namespace OrderappisTest
{
    public class UnitAuthServiceTest
    {
        [Fact]
        public void TestUserAuth()
        {
            // zkušební uživatel bude zákazník
            string username = "z00001";
            string password = "123";

            // log in
            AuthService.Instance.StartLoginAction(username, password);
            var User = AuthService.Instance.CurrentUser;

            Assert.True(User != null);
            Assert.Equal(User.Login, username);

            // log out
            AuthService.Instance.Logout();
            User = AuthService.Instance.CurrentUser;
            Assert.True(User == null);
        }
    }
}