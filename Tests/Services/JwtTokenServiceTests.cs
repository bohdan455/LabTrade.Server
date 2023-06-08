using BLL.Services.Interfaces;
using BLL.Services.Realizations.Jwt;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services
{
    public class JwtTokenServiceTests
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly IConfiguration _config;
        public JwtTokenServiceTests()
        {
            var configData = new Dictionary<string, string>()
            {
                {"JwtSettings:Key","9daCpf+b7Tf^DVQ#ms8T^p@ERs!uW3Kq"}
            };
            _config = new ConfigurationBuilder().AddInMemoryCollection(configData).Build();
            _jwtTokenService = new JwtTokenService(_config);
        }
        [Fact]
        public void GenerateToken_GivenNoArguments_ReturnsToken()
        {
            // Arrange
            // Act
            var token = _jwtTokenService.GenerateToken();
            // Assert
            Assert.False(string.IsNullOrEmpty(token));
        }
        [Fact]
        public void GenerateToken_GivenNullArgument_ReturnsToken()
        {
            // Arrange
            // Act
            var token = _jwtTokenService.GenerateToken(null);
            // Assert
            Assert.False(string.IsNullOrEmpty(token));
        }
        [Fact]
        public void GenerateToken_GiveArguments_ReturnsToken()
        {
            // Arrange
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, "a"),
                new Claim(ClaimTypes.Email, "b@gmail.com")
            };
            // Act
            var token = _jwtTokenService.GenerateToken(claims);

            // Assert

            Assert.False(string.IsNullOrEmpty(token));
        }
        [Fact]
        public void GenerateToken_GiveNoArguments_ReturnsNoCustomClaims()
        {
            // Arrange
            var jwtHandler = new JwtSecurityTokenHandler();
            var defaultLengthOfClaims = 3;

            // Act
            var token = _jwtTokenService.GenerateToken();
            var returnedClaims = jwtHandler.ReadJwtToken(token).Claims;

            // Assert
            Assert.Equal(defaultLengthOfClaims, returnedClaims.Count());
        }
        [Fact]
        public void GenerateToken_GivenCustomArguments_ReturnsGivenCustomArguments()
        {
            // Arrange 
            var jwtHandler = new JwtSecurityTokenHandler();
            var claims = new Claim[] {
                new Claim("Name", "a"),
                new Claim("Email", "b@gmail.com")
            };
            // Act 
            var token = _jwtTokenService.GenerateToken(claims);
            var returnedClaims = jwtHandler.ReadJwtToken(token).Claims.ToArray();

            // Assert
            Assert.All(claims, claim =>
            {
                Assert.True(Array.Exists(returnedClaims,
                    returnedClaim => returnedClaim.Type == claim.Type && returnedClaim.Value == claim.Value));
            });
        }

    }
}
