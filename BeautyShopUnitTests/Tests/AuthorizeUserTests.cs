using System.Net;
using BeautyShopBL.Authorization;
using BeautyShopBL.Authorization.Entities;
using BeautyShopBL.Users.Entity;
using BeautyShopBL.Users.Manager;
using BeautyShopDataAccess.Entities;
using BeautyShopUnitTests.Tests.Endpoints;
using DataAccess.Repository;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace BeautyShopUnitTests.Tests;

public class AuthorizeUserTests: BeautyShopTestsBase
{
     [Test]
    public async Task AuthorizeTest()
    {
        var password = "12345678";
        var email = "em_vera@mail.ru";
        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var authProvider = scope.ServiceProvider.GetRequiredService<IAuthProvider>();
        var userModel = await authProvider.RegisterUser(email, password);
        var query = $"?email={email}"
                    + $"&password={password}";
        var requestUri =
            ApiEndpoints.AuthorizeUserEndpoint + query;
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var client = TestHttpClient;
        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var responseContentJson = await response.Content.ReadAsStringAsync();
        var content = JsonConvert.DeserializeObject<TokensResponse>(responseContentJson);
        content.Should().NotBeNull();
        content.AccessToken.Should().NotBeNull();
        content.RefreshToken.Should().NotBeNull();
        var usersManager = scope.ServiceProvider.GetRequiredService<IUsersManager>();
        usersManager.DeleteUser(userModel.Id);
    }
    [Test]
    public async Task AuthorizeWithoutRegistrationTest()
    {
        var password = "12345678";
        var email = "em_vera@mail.ru";
        var query = $"?email={email}"
                       + $"&password={password}";
        var requestUri = ApiEndpoints.AuthorizeUserEndpoint + query;
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var client = TestHttpClient;
        var response = await client.SendAsync(request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    [Test]
    public async Task AuthorizeWithWrongDataTest()
    {
        var password = "12345678";
        var email = "em_vera@mail.ru";
        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var authProvider = scope.ServiceProvider.GetRequiredService<IAuthProvider>();
        var userModel = await authProvider.RegisterUser(email, password);
        const string wrongEmail = "wrong@mail.ru";
        var wrongQuery1 = $"?email={wrongEmail}"
                    + $"&password={password}";
        var requestUri1 =
            ApiEndpoints.AuthorizeUserEndpoint + wrongQuery1;
        var request1 = new HttpRequestMessage(HttpMethod.Get, requestUri1);
        const string wrongPassword = "00000000";
        var wrongQuery2 = $"?email={email}"
                          + $"&password={wrongPassword}";
        var requestUri2 =
            ApiEndpoints.AuthorizeUserEndpoint + wrongQuery2;
        var request2 = new HttpRequestMessage(HttpMethod.Get, requestUri2);
        var client = TestHttpClient;
        var response = await client.SendAsync(request1);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        response = await client.SendAsync(request2);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var usersManager = scope.ServiceProvider.GetRequiredService<IUsersManager>();
        usersManager.DeleteUser(userModel.Id);
    }
    
    [Test]
    public async Task RegisterTest()
    {
        var password = "12345678";
        var email = "em_vera@mail.ru";
        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var authProvider = scope.ServiceProvider.GetRequiredService<IAuthProvider>();
        var userModel = await authProvider.RegisterUser(email, password);
        var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<UserEntity>>();
        var userEntity = userRepository.GetById(userModel.Id);
        userEntity.Should().NotBeNull();
        userEntity.Email.Should().Be(email);
        userRepository.Delete(userEntity);
    }
    [Test]
    public async Task RegisterUserThatAlreadyExistsTest()
    {
        var password = "12345678";
        var email = "em_vera@mail.ru";
        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var authProvider = scope.ServiceProvider.GetRequiredService<IAuthProvider>();
        var userModel = await authProvider.RegisterUser(email, password);
        Func<Task<UserModel>> expectedAct = async () => await authProvider.RegisterUser(email, password);
        await expectedAct.Should().ThrowAsync<Exception>();
        var userManager = scope.ServiceProvider.GetRequiredService<IUsersManager>();
        userManager.DeleteUser(userModel.Id);
    }
    [Test]
    public async Task RegisterUserWithWrongData()
    {
        var password = "12345678";
        var email = "em_vera@mail.ru";
        using var scope = GetService<IServiceScopeFactory>().CreateScope();
        var authProvider = scope.ServiceProvider.GetRequiredService<IAuthProvider>();
        password = "1";
        Func<Task<UserModel>> expectedAct = async () => await authProvider.RegisterUser(email, password);
        await expectedAct.Should().ThrowAsync<Exception>();
        password = "12345678";
        email = "1";
        expectedAct = async () => await authProvider.RegisterUser(email, password);
        await expectedAct.Should().ThrowAsync<Exception>();
        email = "em_vera@mail.ru";
    }
}